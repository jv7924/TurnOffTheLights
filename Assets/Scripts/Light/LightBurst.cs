using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBurst : MonoBehaviour
{
    public bool BurstInProgress { get; private set; }

    private bool damaged;

    float lerpDuration = 1;

    public IEnumerator Burst(Light2D light)
    {
        damaged = false;
        
        BurstInProgress = true;

        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            light.intensity = Mathf.Lerp(5, 2.5f, timeElapsed / lerpDuration);
            light.falloffIntensity = Mathf.Lerp(0.2f, 0.5f, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        light.intensity = 2.5f;
        light.falloffIntensity = 0.5f;

        yield return new WaitForSecondsRealtime(1f);

        BurstInProgress = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && BurstInProgress && !damaged)
        {
            other.gameObject.GetComponent<HealthSystem>().Damage(1);
            damaged = true;
        }
    }


    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Enemy") && BurstInProgress)
    //     {
    //         bool firstTime = true;

    //         while (firstTime)
    //         {    
    //             Debug.Log("inside flash");
    //             other.gameObject.GetComponent<HealthSystem>().Damage(1);
    //             firstTime = false;
    //         }
    //     }
    // }

}
