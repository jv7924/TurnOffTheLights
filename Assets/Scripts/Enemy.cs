using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(.01f, .05f)]
    public float distCast = .05f;
    [Range(0f, 180f)]
    public float angle = 0f;

    public Collider2D col;
    private bool canWalk = true;
    // public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    // private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = player.position - transform.position;
        // dir.Normalize();
        // direction = dir;
        CanWalk();
        if (canWalk)
            rb.velocity = new Vector2(1 * moveSpeed, rb.velocity.y);

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        // FollowPlayer(direction);
    }

    // private void FollowPlayer(Vector2 direction)
    // {
    //     rb.velocity = new Vector2(transform.position.x + direction.x * moveSpeed, rb.velocity.y);
    //     // rb.MovePosition((Vector2)transform.position + direction * moveSpeed * Time.deltaTime);
    // }

    private void CanWalk()
    {

        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size - new Vector3(0, .1f, 0), angle, Vector2.right, distCast);


        if (raycastHit.collider != null)
        {
            canWalk = false;
        }
        else 
        {
            canWalk = true;
        }
    }
}
