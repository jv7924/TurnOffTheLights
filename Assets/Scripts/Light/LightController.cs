using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private LightRotation lightRotation;
    [SerializeField] private LightFlicker lightFlicker;

    [Space(5)]
    [Header("Rotation Variables")]
    [SerializeField, Range(1f, 5f), Tooltip("Flashlight rotate speed")]
    private float rotateSpeed = 2.5f;
    [SerializeField, Range(30f, 60f), Tooltip("Amount of rotation applied")]
    private float rotateAngle = 45f;


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
        
        lightRotation.LightRotate(direction, rotateAngle, rotateSpeed);
    }
}
