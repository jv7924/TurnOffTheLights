using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump(Rigidbody2D player, float force)
    {
        player.velocity = new Vector2(player.velocity.x, 4);
    }
}
