using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void Move(Rigidbody2D player, float direction, float speed)
    {
        FlipPlayer(direction);
        player.velocity = new Vector2(direction * speed, player.velocity.y);
    }

    private void FlipPlayer(float direction)
    {
        if (direction != 0)
            gameObject.transform.localScale = new Vector3(direction, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }

    // private void FlipPlayer(float direction)
    // {
        // Quaternion leftRot = Quaternion.Euler(0f, 180f, 0f);
        // Quaternion rightRot = Quaternion.Euler(0f, 0f, 0f);

        // switch (direction)
        // {
        //     case 1:
        //         gameObject.transform.rotation = rightRot;
        //         break;
        //     case -1:
        //         gameObject.transform.rotation = leftRot;
        //         break;
        // }
    // }
}