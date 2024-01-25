using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public float attackSpeed;
    public float retractSpeed;

    private Collider2D col;
    private int direction = 1;
    public int playerCheckDistcast = 5;
    public int damageAmount = 2;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInRange();
    }

    private void PlayerInRange()
    {
        // RaycastHit2D raycastHit = Physics2D.Raycast(col.bounds.center, new Vector2(direction, 0f), 5f, playerLayer);
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size + new Vector3(1f, 0, 0), 0, new Vector2(0f, -direction), playerCheckDistcast, playerLayer);

        // Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x, 0f, 0f), new Vector3(0f, direction, 0f) * (col.bounds.extents.x + playerCheckDistcast), Color.black);
        // Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x, 0f, 0f), new Vector3(0f, direction, 0f) * (col.bounds.extents.x + playerCheckDistcast), Color.black);

        if (raycastHit.collider != null)
        {
            Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x + .5f, 0f, 0f), new Vector3(0f, -direction, 0f) * (col.bounds.extents.y + playerCheckDistcast), Color.green);
            Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x + .5f, 0f, 0f), new Vector3(0f, -direction, 0f) * (col.bounds.extents.y + playerCheckDistcast), Color.green);

            transform.position = Vector2.MoveTowards(transform.position, endPos.position, attackSpeed * Time.deltaTime);
        }
        else
        {
            Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x + .5f, 0f, 0f), new Vector3(0f, -direction, 0f) * (col.bounds.extents.y + playerCheckDistcast), Color.red);
            Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x + .5f, 0f, 0f), new Vector3(0f, -direction, 0f) * (col.bounds.extents.y + playerCheckDistcast), Color.red);

            transform.position = Vector2.MoveTowards(transform.position, startPos.position, retractSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthSystem>().Damage(damageAmount);
        }
    }

    // private IEnumerator Attack(Vector2 targetPosition, float duration)
    // {
    //     isMoving = true;
        
    //     float time = 0;
    //     Vector2 startPosition = transform.position;
    //     while (time < duration)
    //     {
    //         transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
    //         // transform.position = Vector2.MoveTowards(startPosition, targetPosition, duration * Time.deltaTime);
    //         time += Time.deltaTime;
    //         yield return null;
    //     }

    //     transform.position = targetPosition;
        
    //     isMoving = false;
    // }

    // private IEnumerator Retract(Vector2 targetPosition, float duration)
    // {
    //     isMoving = true;

    //     float time = 0;
    //     Vector2 startPosition = transform.position;
    //     while (time < duration)
    //     {
    //         transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
    //         time += Time.deltaTime;
    //         yield return null;
    //     }

    //     transform.position = targetPosition;

    //     isMoving = false;
    // }

}
