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
    [SerializeField] private MovingPlatform platform;
    
    [Space(5)]
    [Header("Movement Variables")]
    [Range(0.0f, 10.0f), Tooltip("Player move speed")]
    [SerializeField] private float moveSpeed = 0;
    [Range(0.0f, 10.0f), Tooltip("Player jump speed")]
    [SerializeField] private float jumpSpeed = 0;

    private Rigidbody2D playerRB;
    private Collider2D playerCol;
    private PlayerControl playerControl;
    [SerializeField] private LayerMask layerMask;
    
    [SerializeField] private PhysicsMaterial2D material2D;

    private bool onPlat = false;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<Collider2D>();

        playerControl = new PlayerControl();
        playerControl.Player.Enable();

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
        movement.Move(playerRB, direction, moveSpeed, onPlat, platform);

        change.ChangeMaterial(playerCol, direction, layerMask, material2D);

        jump.Grounded(playerCol, layerMask);
    } 

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            onPlat = true;
            Debug.Log("hi");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
            onPlat = false;
    }
}
