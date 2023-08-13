using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheckForPlayerUnder : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Collider2D playerCol;

    private Transform platTransform;
    private Collider2D platCol;
    // Start is called before the first frame update
    void Start()
    {
        platTransform = GetComponent<Transform>();
        platCol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y - playerCol.bounds.extents.y < platTransform.position.y - platCol.bounds.extents.y)
            platCol.enabled = false;
        else 
            platCol.enabled = true;
    }
}
