using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void Move(Rigidbody2D player, float direction, float speed)
    {
        player.velocity = new Vector2(direction * speed, player.velocity.y);
    }
}
