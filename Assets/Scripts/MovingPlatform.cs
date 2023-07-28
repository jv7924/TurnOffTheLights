using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform startPos;
    public Transform endPos;
    public Rigidbody2D platRB;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startPos.position;
        // StartCoroutine(Plat(startPos, endPos, speed));
    }

    // Update is called once per frame
    void Update()
    {

        // ToStart(startPos, endPos, speed);
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
