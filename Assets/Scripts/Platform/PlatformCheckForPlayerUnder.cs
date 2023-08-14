using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheckForPlayerUnder : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Collider2D playerCol;

    private Transform platTransform;
    private Collider2D platCol;
    private bool under = false;

    [SerializeField] private LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        platTransform = GetComponent<Transform>();
        platCol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (under)
            platCol.enabled = false;
        else 
            platCol.enabled = true;

        CheckForPlayerUnder();
    }

    private void CheckForPlayerUnder()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, transform.localScale, 0f, Vector2.down, 2f, playerLayer);

        Color rayCol;
        if (raycastHit.collider == null)
        {
            under = false;
            rayCol = Color.red;
        }
        else
        {
            under = true;
            rayCol = Color.green;
        }

        Debug.DrawRay(platCol.bounds.center + new Vector3(platCol.bounds.extents.x, 0, 0), Vector3.down * 2f, rayCol);
        Debug.DrawRay(platCol.bounds.center - new Vector3(platCol.bounds.extents.x, 0, 0), Vector3.down * 2f, rayCol);
    }
}
