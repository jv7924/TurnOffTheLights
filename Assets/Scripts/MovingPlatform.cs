using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform startPos;
    public Transform endPos;
    public Rigidbody2D platRB;

    public float x;
    public float y;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        gameObject.transform.position = startPos.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(MovePlatform(startPos.position, endPos.position));
        // StartCoroutine(LerpPosition(endPos.position, speed));

        // StartCoroutine(Plat(startPos, endPos, speed));
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        Debug.Log(platRB.velocity);
        MovePlatform(startPos.position, endPos.position, speed);
    }

    // IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    // {
    //     float time = 0;
    //     while (time < duration)
    //     {
    //         platRB.MovePosition(Vector2.Lerp(startPos.position, targetPosition, time / duration));
    //         time += Time.deltaTime;
    //         yield return null;
    //     }
    //     transform.position = targetPosition;
    // }

    private void MovePlatform(Vector2 start, Vector2 end, float speed)
    {
        if ((Vector2)transform.position != end)
        {
            platRB.velocity = new Vector2(end.x - start.x, end.y - start.y).normalized * speed;
        }
        // else if ((Vector2)transform.position != start)
        // {
        //     platRB.velocity = new Vector2(start.x - end.x, start.y - end.y).normalized * speed;
        // }
    }

    // private IEnumerator Plat(Transform start, Transform end, float speed)
    // {
    //     while(true)
    //     {
    //         if (gameObject.transform.position == start.position)
    //         {
    //             platRB.MovePosition(gameObject.transform.position + end.position * speed * Time.deltaTime);
    //         }
    //         yield return null;
    //     }

    // }
    
}
