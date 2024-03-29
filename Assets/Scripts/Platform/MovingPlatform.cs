using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    private int currentWayPointIndex = 0;
    public bool ready;

    [SerializeField] private Transform[] wayPoints;

    private void Awake()
    {
        gameObject.transform.position = wayPoints[0].position;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(wayPoints[currentWayPointIndex].position, transform.position) < .001f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= wayPoints.Length)
                currentWayPointIndex = 0;
        
            StartCoroutine(Wait());
        }

        MovePlatform(wayPoints[currentWayPointIndex].position, speed);
    }

    private void MovePlatform(Vector2 target, float speed)
    {
        if (ready)
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private IEnumerator Wait()
    {
        ready = false;

        yield return new WaitForSecondsRealtime(1.5f);

        ready = true;

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
