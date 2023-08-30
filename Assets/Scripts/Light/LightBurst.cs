using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBurst : MonoBehaviour
{
    public bool BurstInProgress { get; private set; }

    float lerpDuration = 2;

    public IEnumerator Burst(Light2D light)
    {
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
        if (other.gameObject.CompareTag("Enemy") && BurstInProgress)
        {
            Debug.Log("Enemy in range");
            other.gameObject.GetComponent<HealthSystem>().Damage(1);
        }
    }
}
