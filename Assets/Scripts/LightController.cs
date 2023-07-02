using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{
    private PlayerControl lightControl;
    
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
        // OutOfBounds();
        gameObject.transform.Rotate(new Vector3(0, 0, direction * 2));
    }

}
