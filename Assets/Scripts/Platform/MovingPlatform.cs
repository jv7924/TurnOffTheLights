using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform start;
    public Transform end;

    [SerializeField] private Transform[] wayPoints;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        gameObject.transform.position = start.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
    //     if (transform.position == end.position)
    //     {
    //         // StartCoroutine(LerpPosition(end.position, start.position, speed));
    //         transform.position = Vector2.MoveTowards(transform.position, start.position, speed * Time.deltaTime);
    //     }
        // else if (transform.position == start.position)
        // {
            // StartCoroutine(LerpPosition(start.position, end.position, speed));
            transform.position = Vector2.MoveTowards(transform.position, end.position, speed * Time.deltaTime);

        // }
    }

    private void MovePlatform(Vector2 target, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // IEnumerator LerpPosition(Vector2 startPosition, Vector2 targetPosition, float duration)
    // {
    //     float time = 0;

    //     while (time < duration)
    //     {
    //         // platRB.MovePosition(Vector2.Lerp(startPosition, targetPosition, time / duration));
    //         transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
    //         time += Time.deltaTime;
    //         yield return null;
    //     }
    //     transform.position = targetPosition;
    // }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(start.position, end.position);
    }
}
