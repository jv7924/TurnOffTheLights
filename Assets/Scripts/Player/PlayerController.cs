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
    [SerializeField] private PhysicsMaterial2D material2D;

    private Rigidbody2D playerRB;
    private Collider2D playerCol;
    private PlayerControl playerControl;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<Collider2D>();

        playerControl = new PlayerControl();
        playerControl.Player.Enable();

        // playerControl.Player.Jump.performed += PerformJump;
        // playerControl.Player.Jump.canceled += PerformFastFall;
    }

    private void PerformJump()
    {
        jump.Grounded(playerCol, layerMask);

        bool buttonHeld = playerControl.Player.Jump.ReadValue<float>() > 0.1f;
        jump.Jump(playerRB, jumpSpeed, lowJumpMultiplier, fallMultiplier, buttonHeld);
    }

    // private void PerformFastFall(InputAction.CallbackContext context)
    // {
    //     Debug.Log("canceled");
    //     jump.FastFall(playerRB);
    // }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float direction = playerControl.Player.Move.ReadValue<float>();
        movement.Move(playerRB, direction, moveSpeed);

        change.ChangeMaterial(playerCol, direction, layerMask, material2D);

        PerformJump();
    } 
}
