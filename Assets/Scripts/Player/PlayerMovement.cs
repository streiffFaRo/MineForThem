using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Componenten & Scripts
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private PlayerInputScript playerInputScript;
    
    //Variablen
    private float currentMoveSpeed;
    private bool gameIsPaused;
    
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

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInputScript = GetComponent<PlayerInputScript>();
    }

    private void OnEnable()
    {
        PlayerInputScript.onMoveEvent += Flip;
        PlayerInputScript.onJumpEvent += Jump;
        PlayerInputScript.onBackEvent += PauseMenu;
    }
    
    private void OnDisable()
    {
        PlayerInputScript.onMoveEvent -= Flip;
        PlayerInputScript.onJumpEvent -= Jump;
        PlayerInputScript.onBackEvent -= PauseMenu;
    }

    private void FixedUpdate()
    {
        if (rigidbody != null)
        {
            rigidbody.velocity = new Vector2(playerInputScript.lastInput.x * currentMoveSpeed * Time.deltaTime, rigidbody.velocity.y);
        }
        
    }
    
    private void Update()
    {
        HandlePlayerMovement();
    }
    
    private void HandlePlayerMovement()
    {
        if (playerInputScript.moveInput != Vector2.zero)
        {
            playerInputScript.lastInput = playerInputScript.moveInput;
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

    private void Flip()
    {
        if (playerInputScript.moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        
    }
    
    private void Jump()
    {
        if (IsGrounded())
        {
            rigidbody.AddForce(new Vector2(rigidbody.velocity.x,jumpForce));
        }
    }
    
    public bool IsGrounded()
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
}
