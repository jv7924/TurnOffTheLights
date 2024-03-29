using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Range(.1f, 1f)] private float wallCheckDistCast;
    [SerializeField, Range(.1f, 1f)] private float groundCheckDistCast;
    [SerializeField, Range(.1f, 8f)] private float playerCheckDistcast;
    private float angle = 0f;

    // Layers
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask playerLayer;

    private Collider2D col;
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float direction = 1;

    [SerializeField] private bool wallCheck = true;
    [SerializeField] private bool groundCheck = true;
    [SerializeField] private bool playerCheck = true;

    [SerializeField] private int damageAmount;

    private HealthSystem health;

    // private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        health = GetComponent<HealthSystem>();
        if (health != null)
        {
            health.OnPlayerDead += HandleEnemyDeadEvent;
            health.OnPlayerTakeDamage += HandleEnemyDamagedEvent;
        }
    }

    private void FixedUpdate()
    {
        if (wallCheck)
            WallCheck();

        if (groundCheck)
            GroundCheck();

        if (playerCheck && PlayerInRange())
            rb.velocity = new Vector2(direction * moveSpeed * 2, rb.velocity.y);
        else
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    private void WallCheck()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(col.bounds.center + new Vector3(.1f * direction, 0f, 0f), new Vector2(direction, 0f), wallCheckDistCast, groundLayer);

        Color rayCol;
        if (raycastHit.collider != null)
        {
            rayCol = Color.red;
            direction *= -1;
        }
        else
            rayCol = Color.green;

        Debug.DrawRay(col.bounds.center + new Vector3(.1f * direction, 0f, 0f), new Vector2(direction, 0f) * wallCheckDistCast, rayCol);

        // RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size - new Vector3(0, .1f, 0), angle, new Vector2(direction, 0f), distCast, groundLayer);
        // Debug.DrawRay(col.bounds.center + new Vector3(0f, col.bounds.extents.y - .05f, 0f), new Vector3(direction, 0f, 0f) * (col.bounds.extents.x + distCast), rayCol);
        // Debug.DrawRay(col.bounds.center - new Vector3(0f, col.bounds.extents.y - .05f, 0f), new Vector3(direction, 0f, 0f) * (col.bounds.extents.x + distCast), rayCol);
        // Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x + distCast, 0f, 0f), Vector3.down * col.bounds.extents.y + new Vector3(0f, .05f, 0f), rayColor);
        // Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x + distCast, 0f, 0f), Vector3.up * col.bounds.extents.y - new Vector3(0f, .05f, 0f), rayColor);
    }

    private void GroundCheck()
    {
        // RaycastHit2D raycastHit = Physics2D.Raycast(col.bounds.center + new Vector3(col.bounds.extents.x + .01f, -.01f, 0f), new Vector2(direction, -1.5f), distCast, groundLayer);
        float boxSize = 0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(new Vector2(col.bounds.center.x + (col.bounds.extents.x + (boxSize / 2)) * direction, col.bounds.center.y - col.bounds.extents.y), new Vector2(boxSize, boxSize), angle, new Vector2(direction, 0f), groundCheckDistCast, groundLayer);

        Color rayCol;
        if (raycastHit.collider != null)
        {
            rayCol = Color.red;
        }
        else
        {
            direction *= -1;
            rayCol = Color.blue;
        }

        Debug.DrawRay(new Vector2(col.bounds.center.x + col.bounds.extents.x * direction, col.bounds.center.y - col.bounds.extents.y), new Vector2(direction * boxSize, 0f), rayCol);
        Debug.DrawRay(new Vector2(col.bounds.center.x + col.bounds.extents.x * direction, col.bounds.center.y - col.bounds.extents.y - (boxSize / 2)), new Vector2(direction * boxSize, 0f), rayCol);

        // Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x * direction - .01f, -.01f, 0f), new Vector2(direction, -1.5f) * distCast, rayCol);
    }

    private bool PlayerInRange()
    {
        // RaycastHit2D raycastHit = Physics2D.Raycast(col.bounds.center, new Vector2(direction, 0f), 5f, playerLayer);
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size - new Vector3(0, .5f, 0), angle, new Vector2(direction, 0f), playerCheckDistcast, playerLayer);

        Debug.DrawRay(col.bounds.center + new Vector3(0f, col.bounds.extents.y, 0f), new Vector3(direction, 0f, 0f) * (col.bounds.extents.x + playerCheckDistcast), Color.black);
        Debug.DrawRay(col.bounds.center - new Vector3(0f, col.bounds.extents.y, 0f), new Vector3(direction, 0f, 0f) * (col.bounds.extents.x + playerCheckDistcast), Color.black);

        if (raycastHit.collider != null && raycastHit.collider.gameObject.CompareTag("Player"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator EnemyStunned()
    {
        float ogMoveSpeed = moveSpeed;
        moveSpeed = 0;

        yield return new WaitForSecondsRealtime(2.0f);

        moveSpeed = ogMoveSpeed;
    }

    private void HandleEnemyDamagedEvent()
    {
        Debug.Log("Enemy damaged");
        StartCoroutine(EnemyStunned());
    }

    private void HandleEnemyDeadEvent()
    {
        Debug.Log("Enemy Dead");
        health.OnPlayerDead -= HandleEnemyDeadEvent;
        health.OnPlayerTakeDamage -= HandleEnemyDamagedEvent;
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthSystem>().Damage(damageAmount);
        }
    }
}
