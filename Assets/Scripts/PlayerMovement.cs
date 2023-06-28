using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Rigidbody2D player, float speed)
    {
        player.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
    }
}
