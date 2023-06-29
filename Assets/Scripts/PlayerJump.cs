using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public void Jump(Rigidbody2D player, float speed)
    {
        if (IsGrounded())
           player.velocity = new Vector2(player.velocity.x, speed);
    }

    private bool IsGrounded()
    {

        return false;
    }
}
