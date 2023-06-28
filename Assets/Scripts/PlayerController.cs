using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerMovement movement;
    
    [Space(5)]
    [Header("Movement Variables")]
    [Range(0.0f, 10.0f), Tooltip("Player speed")]
    [SerializeField] private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.Move(speed);
    }
}
