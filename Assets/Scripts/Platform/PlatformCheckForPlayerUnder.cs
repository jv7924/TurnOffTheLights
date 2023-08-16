using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheckForPlayerUnder : MonoBehaviour
{
    private Collider2D platCol;
    private bool under = false;

    [SerializeField] private LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
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
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, transform.localScale + new Vector3(1f, 0f, 0f), 0f, Vector2.down, 1f, playerLayer);

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

        Debug.DrawRay(transform.position + new Vector3(transform.localScale.x/2 + 0.5f, 0, 0), Vector3.down * 1f, rayCol);
        Debug.DrawRay(transform.position - new Vector3(transform.localScale.x/2 + 0.5f, 0, 0), Vector3.down * 1f, rayCol);
    }
}
