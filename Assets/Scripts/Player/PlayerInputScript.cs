using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.XR;

public class PlayerInputScript : MonoBehaviour
{
    //Variablen
    private Player_Input_Map input;
    public Vector2 moveInput { get; private set; }
    public Vector2 lastInput;
    public bool canMove = true;
    
    //Scripts
    private Interaction interactionScript;
    private MiningSystem miningSystem;
    private ActivityController activityController;
    
    //Event
    public static event Action onMoveEvent;
    public static event Action onJumpEvent;
    public static event Action onBackEvent;

    private void Awake()
    {
        input = new Player_Input_Map();
        
        interactionScript = GetComponent<Interaction>();
        miningSystem = GetComponent<MiningSystem>();
        activityController = FindObjectOfType<ActivityController>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += OnMoveInput;
        input.Player.Move.canceled += OnMoveInput;
        input.Player.Jump.performed += OnJumpInput;
        input.Player.Interact.performed += OnInterationInput;
        input.Player.Back.performed += OnBackInput;
        input.Player.Destroy.performed += OnDestroyInput;
        input.Player.Place.performed += OnPlaceInput;
        input.Player.Enter.performed += OnEnterInput;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= OnMoveInput;
        input.Player.Move.canceled -= OnMoveInput;
        input.Player.Jump.performed -= OnJumpInput;
        input.Player.Interact.performed -= OnInterationInput;
        input.Player.Back.performed -= OnBackInput;
        input.Player.Destroy.performed -= OnDestroyInput;
        input.Player.Place.performed -= OnPlaceInput;
        input.Player.Enter.performed -= OnEnterInput;
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed && canMove)
        {
            moveInput = context.ReadValue<Vector2>().normalized;
            onMoveEvent?.Invoke();
        }
        else
        {
            moveInput = Vector2.zero;
        }
    }
    
    private void OnJumpInput(InputAction.CallbackContext context)
    {

        if (context.performed && canMove)
        {
            onJumpEvent?.Invoke();
        }

    }

    private void OnInterationInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactionScript.Interact();
        }
    }
    
    private void OnBackInput(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            onBackEvent?.Invoke();
            //TODO Firstselected
        } 
    }
    
    
    private void OnDestroyInput(InputAction.CallbackContext obj)
    {
        if (canMove)
        {
            miningSystem.DestroyBlock(MousePos2D());
        }

    }
    
    private void OnPlaceInput(InputAction.CallbackContext obj)
    {
        if (canMove)
        {
            miningSystem.PlaceBlock(MousePos2D());
        }
    }

    private static Vector3Int MousePos2D()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mousePos2D = new Vector3Int(Mathf.FloorToInt(mouseWorldPos.x), Mathf.FloorToInt(mouseWorldPos.y), 0);
        return mousePos2D;
    }

    private void OnEnterInput(InputAction.CallbackContext obj)
    {
        activityController?.ContinueStory();
    }
    
}
