using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    // Look into using oscillating sinusodal waves
    public IEnumerator Flicker(Light2D flash)
    {
        
        for (int i = 50; i > 0; i--)
        {
            if (i == 45)
            {
                flash.intensity = 0; 
                yield return new WaitForSeconds(0.5f);
                flash.intensity = 2.5f;
            }
            else if (i == 22)
            {
                flash.intensity = 0; 
                yield return new WaitForSeconds(0.5f);
                flash.intensity = 2.5f;
            }
            else if (i == 11)
            {
                flash.intensity = 0; 
                yield return new WaitForSeconds(0.5f);
                flash.intensity = 2.5f;
            }
            else if (i == 5)
            {
                flash.intensity = 0; 
                yield return new WaitForSeconds(0.5f);
                flash.intensity = 2.5f;
            }
            else if (i == 2)
            {
                flash.intensity = 0; 
                yield return new WaitForSeconds(0.5f);
                flash.intensity = 2.5f;
            }
            else if (i == 1)
                flash.intensity = 0;

            yield return new WaitForSeconds(1f);
        }

        yield return null;
    }
}
