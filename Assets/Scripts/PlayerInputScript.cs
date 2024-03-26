using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.XR;

public class PlayerInputScript : MonoBehaviour
{
    private Player_Input_Map input;
    private Vector2 moveInput;
    private Vector2 lastInput;
    private Rigidbody2D rigidbody;
    private Interaction interactionScript;
    private SpriteRenderer spriteRenderer;
    private ActivityController activityController;
    private float currentMoveSpeed;
    private bool gameIsPaused;
    private bool canMove = true;

    [Header("Movement")]
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float decelerationSpeed;
    [SerializeField] private float maxSpeed;
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Gameobjects")] 
    [SerializeField] private Canvas PauseMenuCanvas;

    private MiningSystem miningSystem;


    private void Awake()
    {
        input = new Player_Input_Map();
        
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactionScript = GetComponent<Interaction>();
        miningSystem = GetComponent<MiningSystem>();
        activityController = FindObjectOfType<ActivityController>();
    }

    private void Update()
    {
        HandlePlayerMovement();
    }

    private void FixedUpdate()
    {
        if (rigidbody != null)
        {
            rigidbody.velocity = new Vector2(lastInput.x * currentMoveSpeed * Time.deltaTime, rigidbody.velocity.y);
        }
        
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
            Flip();
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
            Jump();
        }

    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rigidbody.AddForce(new Vector2(rigidbody.velocity.x,jumpForce));
        }
    }

    private bool IsGrounded()
    {
        if (groundCheck != null)
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
        else
        {
            return false;
        }
        
    }

    private void Flip()
    {
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    private void HandlePlayerMovement()
    {
        if (moveInput != Vector2.zero)
        {
            lastInput = moveInput;
            if (currentMoveSpeed < maxSpeed)
            {
                currentMoveSpeed += Time.deltaTime * accelerationSpeed;
            }
            else
            {
                currentMoveSpeed = maxSpeed;
            }
        }
        else
        {
            currentMoveSpeed -= Time.deltaTime * decelerationSpeed;
            if (currentMoveSpeed <= 0)
            {
                currentMoveSpeed = 0;
            }
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
            PauseMenu();
            //TODO Firstselected
        } 
    }

    public void PauseMenu()
    {
        if (!gameIsPaused)
        {
            PauseMenuCanvas.gameObject.SetActive(true);
            gameIsPaused = true;
            //TODO PauseSound
        }
        else
        {
            PauseMenuCanvas.gameObject.SetActive(false);
            gameIsPaused = false;
            //TODO UnpauseGameSound
        }
        
    }
    
    private void OnDestroyInput(InputAction.CallbackContext obj)
    {
        //TODO groundcheck
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mousePos2D = new Vector3Int(Mathf.FloorToInt(mouseWorldPos.x), Mathf.FloorToInt(mouseWorldPos.y), 0);

        miningSystem.DestroyBlock(mousePos2D);
    }
    
    private void OnPlaceInput(InputAction.CallbackContext obj)
    {
        //TODO groundcheck
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mousePos2D = new Vector3Int(Mathf.FloorToInt(mouseWorldPos.x), Mathf.FloorToInt(mouseWorldPos.y), 0);
        
        miningSystem.PlaceBlock(mousePos2D);
    }

    private void OnEnterInput(InputAction.CallbackContext obj)
    {
        activityController?.ContinueStory();
    }
    
}
