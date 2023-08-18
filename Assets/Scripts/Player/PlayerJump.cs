using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private bool isGrounded = false;

    public void Jump(Rigidbody2D player, float speed, float lowJumpMultiplier, float fallMultiplier, bool buttonHeld)
    {
        if (isGrounded && buttonHeld)
           player.velocity = new Vector2(player.velocity.x, speed);

        if (player.velocity.y < 0)
            player.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        else if (player.velocity.y > 0 && !buttonHeld)
            player.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
    }

    public void FastFall(Rigidbody2D player)
    {
        // player.velocity += Vector2.up * Time.deltaTime * Physics2D.gravity.y * 100;
        if (player.velocity.y < 0)
            player.velocity += Vector2.down * Physics2D.gravity.y * 3f * Time.deltaTime;
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