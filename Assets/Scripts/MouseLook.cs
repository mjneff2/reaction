using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private PlayerInput inputData;
    private float mouseSensitivity = 30f;
    private float controllerSensitivty = 300f;
    private float verticalMin = -90f;
    private float verticalMax = 90f;

    private float pitch;
    private float yaw;

    // Start is called before the first frame update
    void Start()
    {
        inputData = GetComponentInParent<PlayerInput>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float sensitivity = mouseSensitivity;
        if (inputData.currentControlScheme == "Gamepad")
        {
            sensitivity = controllerSensitivty;
        }
        Vector2 look = inputData.actions["Look"].ReadValue<Vector2>();
        pitch -= look.y * Time.deltaTime * sensitivity;
        pitch = Mathf.Clamp(pitch, verticalMin, verticalMax);
        yaw += look.x * Time.deltaTime * sensitivity;
        Vector3 euler = transform.eulerAngles;
        euler.x = pitch;
        euler.y = yaw;
        transform.eulerAngles = euler;
    }
}
