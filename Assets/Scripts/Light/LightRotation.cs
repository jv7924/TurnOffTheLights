using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightRotation : MonoBehaviour
{
    public void LightRotate(float direction, float angle, float speed)
    {
        Quaternion rotateTo = Quaternion.Euler(0f, gameObject.transform.eulerAngles.y, direction * angle);
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, rotateTo, Time.deltaTime * speed);
    }
}
