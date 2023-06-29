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
    
    [Space(5)]
    [Header("Movement Variables")]
    [Range(0.0f, 10.0f), Tooltip("Player move speed")]
    [SerializeField] private float moveSpeed = 0;
    [Range(0.0f, 10.0f), Tooltip("Player jump speed")]
    [SerializeField] private float jumpSpeed = 0;

    private Rigidbody2D playerRB;
    private PlayerControl playerControl;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();

        playerControl = new PlayerControl();
        playerControl.Player.Enable();

        // playerControl.Player.Move.performed += PerformMove;  Not used if moving with update

        playerControl.Player.Jump.performed += PerformJump;
    }

    private void PerformJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jump.Jump(playerRB, jumpSpeed);
        }
    }

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
    }



    // Not used if moving with update
    // private void PerformMove(InputAction.CallbackContext context)
    // {
    //     if (context.performed)
    //     {
    //         // movement.Move(playerRB, moveSpeed);
    //     }
    // }
}
