using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Range(.01f, .5f)]
    private float distCast = .1f;
    private float angle = 0f;

    [SerializeField] 
    private LayerMask layerMask;
    [SerializeField] 
    private LayerMask layer;
    private Collider2D col;
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float direction = 1;

    // private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        CanWalk();
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    // private void FollowPlayer(Vector2 direction)
    // {
    //     rb.velocity = new Vector2(transform.position.x + direction.x * moveSpeed + 10, rb.velocity.y);
    //     // rb.MovePosition((Vector2)transform.position + direction * moveSpeed * Time.deltaTime);
    // }

    private void CanWalk()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size - new Vector3(0, .1f, 0), angle, new Vector2(direction, 0f), distCast, layerMask);

        if (raycastHit.collider != null)
        {
            direction  *= -1;
        }

        // Debug.DrawRay(col.bounds.center + new Vector3(0f, col.bounds.extents.y - .05f, 0f), new Vector3(direction, 0f, 0f) * (col.bounds.extents.x + distCast), rayColor);
        // Debug.DrawRay(col.bounds.center - new Vector3(0f, col.bounds.extents.y - .05f, 0f), new Vector3(direction, 0f, 0f) * (col.bounds.extents.x + distCast), rayColor);
        // Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x + distCast, 0f, 0f), Vector3.down * col.bounds.extents.y + new Vector3(0f, .05f, 0f), rayColor);
        // Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x + distCast, 0f, 0f), Vector3.up * col.bounds.extents.y - new Vector3(0f, .05f, 0f), rayColor);
    }

    // private bool PlayerInRange()
    // {
    //     RaycastHit2D raycastHit = Physics2D.Raycast(col.bounds.center, new Vector2(direction, 0f), 5f, layer);

    //     if (raycastHit.collider != null)
    //     {
    //         return true;
    //     }
    //     else
    //         return false;
    // }
}
