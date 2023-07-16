using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(.01f, .05f)]
    public float distCast = .1f;
    [Range(0f, 180f)]
    public float angle = 0f;

    public LayerMask layerMask;

    public Collider2D col;
    // private bool canWalk = true;
    // public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    public float direction = 1;

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
        

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        // FollowPlayer(direction);
        CanWalk();
        // if (canWalk)
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    // private void FollowPlayer(Vector2 direction)
    // {
    //     rb.velocity = new Vector2(transform.position.x + direction.x * moveSpeed, rb.velocity.y);
    //     // rb.MovePosition((Vector2)transform.position + direction * moveSpeed * Time.deltaTime);
    // }

    private void CanWalk()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size - new Vector3(0, .1f, 0), angle, new Vector2(0f, direction), distCast, layerMask);

        Color rayColor;
        if (raycastHit.collider == null)
        {
            rayColor = Color.green;
            // canWalk = true;
        }
        else
        {
            rayColor = Color.red;
            // canWalk = false;
            direction *= -1;
        }

        Debug.DrawRay(col.bounds.center + new Vector3(0f, col.bounds.extents.y - .05f, 0f), Vector3.right * (col.bounds.extents.x + distCast), rayColor);
        Debug.DrawRay(col.bounds.center - new Vector3(0f, col.bounds.extents.y - .05f, 0f), Vector3.right * (col.bounds.extents.x + distCast), rayColor);
        Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x + distCast, 0f, 0f), Vector3.down * col.bounds.extents.y + new Vector3(0f, .05f, 0f), rayColor);
        Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x + distCast, 0f, 0f), Vector3.up * col.bounds.extents.y - new Vector3(0f, .05f, 0f), rayColor);
    }
}
