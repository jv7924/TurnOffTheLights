using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    private Collider2D col;
    private int direction = 1;
    public int playerCheckDistcast = 5;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (PlayerInRange())
        {
            Debug.Log("Drop!");
        }
            
    }

    private bool PlayerInRange()
    {
        // RaycastHit2D raycastHit = Physics2D.Raycast(col.bounds.center, new Vector2(direction, 0f), 5f, playerLayer);
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, new Vector2(0f, -direction), playerCheckDistcast, playerLayer);

        // Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x, 0f, 0f), new Vector3(0f, direction, 0f) * (col.bounds.extents.x + playerCheckDistcast), Color.black);
        // Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x, 0f, 0f), new Vector3(0f, direction, 0f) * (col.bounds.extents.x + playerCheckDistcast), Color.black);

        if (raycastHit.collider != null && raycastHit.collider.gameObject.CompareTag("Player"))
        {
            Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x, 0f, 0f), new Vector3(0f, -direction, 0f) * (col.bounds.extents.y + playerCheckDistcast), Color.green);
            Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x, 0f, 0f), new Vector3(0f, -direction, 0f) * (col.bounds.extents.y + playerCheckDistcast), Color.green);
            return true;
        }
        else
        {
            Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x, 0f, 0f), new Vector3(0f, -direction, 0f) * (col.bounds.extents.y + playerCheckDistcast), Color.red);
            Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x, 0f, 0f), new Vector3(0f, -direction, 0f) * (col.bounds.extents.y + playerCheckDistcast), Color.red);
            return false;
        }  
    }
}
