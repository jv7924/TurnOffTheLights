using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform startPos;
    public Transform endPos;
    public Rigidbody2D platRB;

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
        // StartCoroutine(LerpPosition(endPos.position, speed));

        // StartCoroutine(Plat(startPos, endPos, speed));

        Debug.Log(speed/Mathf.Sqrt(Mathf.Pow(endPos.position.x, 2) + Mathf.Pow(endPos.position.y, 2)) * endPos.position.x);
        Debug.Log(speed/Mathf.Sqrt(Mathf.Pow(endPos.position.x, 2) + Mathf.Pow(endPos.position.y, 2)) * endPos.position.y);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        MovePlatform(startPos.position, endPos.position, 2);
        Debug.Log(platRB.velocity);
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


    // Moving platform using velocity
    private void MovePlatform(Vector2 start, Vector2 end, float speed)
    {
        if ((Vector2)transform.position != end)
        {
            platRB.velocity = new Vector2(end.x - start.x, end.y - start.y).normalized * speed;
        }
    }

    // x: 1.94, y: 0.49
    private void VelocityVector()
    {

    }
}
