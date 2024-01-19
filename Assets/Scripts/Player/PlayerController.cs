using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerJump jump;
    [SerializeField] private PlayerMaterialChange change;
    [SerializeField] private PlayerIFrames iFrames;
    
    [Space(5)]
    [Header("Movement Variables")]
    [SerializeField, Range(0.0f, 10.0f), Tooltip("Player move speed")]
    private float moveSpeed = 0;
    [SerializeField, Range(0.0f, 10.0f), Tooltip("Player jump speed")]
    private float jumpSpeed = 0;
    [SerializeField, Range(0.0f, 2.0f), Tooltip("Player low jump fall speed")]
    private float lowJumpMultiplier;
    [SerializeField, Range(0.0f, 3.0f), Tooltip("Player fall speed")]
    private float fallMultiplier; 

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private int layer;
    [SerializeField] private PhysicsMaterial2D material2D;

    private const string RUN_ANIM = "Player_Run";
    private const string IDLE_ANIM = "Player_Idle";
    private const string JUMP_ANIM = "Player_Jump";
    private const string FALL_ANIM = "Player_Fall";

    private Rigidbody2D playerRB;
    private Collider2D playerCol;
    private PlayerControl playerControl;
    private float direction;
    private AnimationController animCon;

    HealthSystem health;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<Collider2D>();
        animCon = GetComponent<AnimationController>();

        playerControl = new PlayerControl();
        playerControl.Player.Enable();
        

        // playerControl.Player.Jump.performed += PerformJump;
        // playerControl.Player.Jump.canceled += PerformFastFall;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthSystem>();
        if (health != null)
        {
            health.OnPlayerTakeDamage += HandlePlayerDamageEvent;
            health.OnPlayerDead += HandlePlayerDeadEvent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRB.velocity.y > .1)
        {
            animCon.ChangeAnimationStates(JUMP_ANIM);
        }
        else if (playerRB.velocity.y < -0.4f)
        {
            animCon.ChangeAnimationStates(FALL_ANIM);
        }

        if (jump.isGrounded)
        {
            if (playerRB.velocity.x > .1f || playerRB.velocity.x < -.1f)
                animCon.ChangeAnimationStates(RUN_ANIM);
            else
                animCon.ChangeAnimationStates(IDLE_ANIM);
        }
    }

    private void FixedUpdate()
    {
        PerformMovement();

        change.ChangeMaterial(playerCol, GetDirection(), layerMask, material2D);

        PerformJump();
    } 

    private void PerformJump()
    {
        jump.Grounded(playerCol, layerMask);

        bool buttonHeld = playerControl.Player.Jump.ReadValue<float>() > 0.1f;
        
        jump.Jump(playerRB, jumpSpeed, lowJumpMultiplier, fallMultiplier, buttonHeld);
    }

    private void PerformMovement()
    {
        SetDirection();
        movement.Move(playerRB, direction, moveSpeed);

        
    }

    private void SetDirection()
    {
        direction = playerControl.Player.Move.ReadValue<float>();
    }

    private float GetDirection()
    {
        return direction;
    }

    private void HandlePlayerDamageEvent()
    {
        StartCoroutine(iFrames.InvinsibilityFrames(layer));
    }

    private void HandlePlayerDeadEvent()
    {
        Debug.Log("The player has dead");
    }
}
