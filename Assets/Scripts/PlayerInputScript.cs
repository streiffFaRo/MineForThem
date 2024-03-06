using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerInputScript : MonoBehaviour
{
    private Player_Input_Map input;
    private Vector2 moveInput;
    private Vector2 lastInput;
    private Rigidbody2D rigidbody;
    private Interaction interactionScript;
    private SpriteRenderer spriteRenderer;
    private float currentMoveSpeed;

    [Header("Movement")]
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float decelerationSpeed;
    [SerializeField] private float maxSpeed;
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private void Awake()
    {
        input = new Player_Input_Map();
        
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactionScript = GetComponent<Interaction>();
    }

    private void Update()
    {
        HandlePlayerMovement();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(lastInput.x * currentMoveSpeed * Time.deltaTime, rigidbody.velocity.y);
        
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += OnMoveInput;
        input.Player.Move.canceled += OnMoveInput;
        input.Player.Jump.performed += OnJumpInput;
        input.Player.Interact.performed += OnInterationInput;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= OnMoveInput;
        input.Player.Move.canceled -= OnMoveInput;
        input.Player.Jump.performed -= OnJumpInput;
        input.Player.Interact.performed -= OnInterationInput;
    }
    
    private void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
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
        
        Jump();
        
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
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
    
}
