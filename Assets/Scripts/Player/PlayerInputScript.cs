using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.XR;

public class PlayerInputScript : MonoBehaviour
{
    
    
    [Header("Variablen")]
    public Vector2 lastInput;
    public bool canMove = true;
    public bool allowInput = true;
    public Vector2 moveInput { get; private set; }
    
    
    [Header("GameObjects")]
    public Canvas pauseMenuCanvas;


    //Scripts
    private Interaction interactionScript;
    private MiningSystem miningSystem;
    private ActivityController activityController;
    
    //Variablen - Privat
    private Player_Input_Map input;
    private bool gameIsPaused;
    
    //Event
    public static event Action onMoveEvent;
    public static event Action onJumpEvent;
    
    //public static event Action onBackEvent;

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
        input.Player.Cheat.performed += OnCheatInput;
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
        input.Player.Cheat.performed -= OnCheatInput;
    }

    private void OnCheatInput(InputAction.CallbackContext context)
    {
        //GameManager gameManager = GameManager.instance;
        //
        if (context.performed)
        {
            Debug.Log("Cheated");
        //    if (gameManager.currentDay <= 3)
        //    {
        //        VolumeManager.instance.GetComponent<AudioManager>().PlayGoldSound();
        //        gameManager.currentDay = 4;
        //        gameManager.savings = 99;
        //        gameManager.hasBullet = true;
        //        gameManager.pickaxeStrength = 100;
        //        gameManager.familyHappiness = 7;
        //    }
        //    else
        //    {
        //        VolumeManager.instance.GetComponent<AudioManager>().PlayPickaxeSound();
        //        gameManager.currentDay = 6;
        //        gameManager.knowsPlan = true;
        //        gameManager.metFriend = true;
        //    }
        }
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed && canMove && allowInput)
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

        if (context.performed && canMove && allowInput)
        {
            onJumpEvent?.Invoke();
        }

    }

    private void OnInterationInput(InputAction.CallbackContext context)
    {
        if (context.performed & allowInput)
        {
            interactionScript?.Interact();
        }
    }
    
    private void OnBackInput(InputAction.CallbackContext context)
    {

        if (context.performed && canMove && allowInput)
        {
            PauseMenu();
        } 
    }
    
    public void PauseMenu()
    {
        if (!gameIsPaused && allowInput)
        {
            pauseMenuCanvas.gameObject.SetActive(true);
            gameIsPaused = true;
            FindObjectOfType<Timer>()?.ToggleTimer();
            VolumeManager.instance.GetComponent<AudioManager>().currentAtmo.Pause();
            VolumeManager.instance.GetComponent<AudioManager>().MenuMusic.Play();
        }
        else if (allowInput)
        {
            pauseMenuCanvas.gameObject.SetActive(false);
            gameIsPaused = false;
            FindObjectOfType<Timer>()?.ToggleTimer();
            VolumeManager.instance.GetComponent<AudioManager>().MenuMusic.Stop();
            VolumeManager.instance.GetComponent<AudioManager>().currentAtmo.UnPause();
        }
        
    }
    
    private void OnDestroyInput(InputAction.CallbackContext context)
    {
        if (context.performed && canMove && allowInput)
        {
            miningSystem?.DestroyBlock(MousePos2D());
        }

    }
    
    private void OnPlaceInput(InputAction.CallbackContext context)
    {
        if (context.performed && canMove && allowInput)
        {
            miningSystem?.PlaceBlock(MousePos2D());
        }
    }

    private static Vector3Int MousePos2D()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mousePos2D = new Vector3Int(Mathf.FloorToInt(mouseWorldPos.x), Mathf.FloorToInt(mouseWorldPos.y), 0);
        return mousePos2D;
    }

    private void OnEnterInput(InputAction.CallbackContext context)
    {
        if (context.performed && allowInput)
        {
            
        }
    }
    
}
