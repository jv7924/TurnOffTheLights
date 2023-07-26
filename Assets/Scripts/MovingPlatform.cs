using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float lerpDuration = 3f;
    private Vector2 startValue;
    private Vector2 endValue;
    
    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LerpToEnd()
    {
        while (timeElapsed < lerpDuration)

        yield return null;
    }

    private IEnumerator LerpToStart()
    {

        yield return null;
    }
}
