using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{
    private PlayerControl lightControl;
    private float rotateAngle = 45f;

    [SerializeField, Range(1f, 5f)]
    private float speed = 1f;
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        lightControl = new PlayerControl();
        lightControl.Light.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = lightControl.Light.MoveLight.ReadValue<float>();
        
        LightMovement(direction);
    }

    private void LightMovement(float direction)
    {
        Quaternion rotateTo = Quaternion.Euler(0f, 0f, direction * rotateAngle);
        // transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, rotateTo, Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, rotateTo, Time.deltaTime * speed);
    }
}
