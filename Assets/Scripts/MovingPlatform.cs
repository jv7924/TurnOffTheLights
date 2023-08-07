using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform start;
    public Transform end;
    public Rigidbody2D platRB;
    public Vector2 platVelocity;

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
        // StartCoroutine(LerpPosition(start.position, end.position, speed));
    }

    private void Update()
    {
        if (transform.position == end.position)
        {
            StartCoroutine(LerpPosition(end.position, start.position, speed));
        }
        else if (transform.position == start.position)
        {
            StartCoroutine(LerpPosition(start.position, end.position, speed));
        }
    }

    IEnumerator LerpPosition(Vector2 startPosition, Vector2 targetPosition, float duration)
    {
        float time = 0;

        SetPlatVelocity(startPosition, targetPosition);
        
        while (time < duration)
        {
            platRB.MovePosition(Vector2.Lerp(startPosition, targetPosition, time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }


    // Moving platform using velocity
    private void SetPlatVelocity(Vector2 start, Vector2 end)
    {
        platVelocity = new Vector2(end.x - start.x, end.y - start.y).normalized;
    }

    public Vector2 GetPlatVelocity()
    {
        return platVelocity;
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(start.position, end.position);
    }
}
