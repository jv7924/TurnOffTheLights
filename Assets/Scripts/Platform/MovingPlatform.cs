using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    private int currentWayPointIndex = 0;

    [SerializeField] private Transform[] wayPoints;

    private void Awake()
    {
        gameObject.transform.position = wayPoints[0].position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(wayPoints[currentWayPointIndex].position, transform.position) < .001f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= wayPoints.Length)
                currentWayPointIndex = 0;
        }

        MovePlatform(wayPoints[currentWayPointIndex].position, speed);
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
        Gizmos.DrawLine(wayPoints[0].position, wayPoints[1].position);
    }
}
