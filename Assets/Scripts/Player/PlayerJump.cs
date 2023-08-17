using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private bool isGrounded = false;

    public void Jump(Rigidbody2D player, float speed)
    {
        if (isGrounded)
           player.velocity = new Vector2(player.velocity.x, speed);
    }

    private void FastFall()
    {
        
    }

    public void Grounded(Collider2D col, LayerMask layerMask)
    {
        float distCast = .05f;
        float angle = 0f;
        
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size - new Vector3(.01f, 0f, 0f), angle, Vector2.down, distCast, layerMask);

        if (raycastHit.collider != null)
            isGrounded = true;
        
        else
            isGrounded = false;
    }
}