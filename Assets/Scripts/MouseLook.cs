﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public string xAxis;
    public string yAxis;

    Vector2 rotation = new Vector2(0,0);
    public float sensitivity = 3;
    public float verticalMin = -30f;
    public float verticalMax = 30f;
    // Start is called before the first frame update
    void Start()
    {
        xAxis = transform.root.gameObject.GetComponent<ControlStrings>().xAxis;
        yAxis = transform.root.gameObject.GetComponent<ControlStrings>().yAxis;
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis(xAxis);
        rotation.x += -Input.GetAxis(yAxis);
        rotation.x = Mathf.Clamp(rotation.x, verticalMin, verticalMax);
        transform.eulerAngles = (Vector2)rotation * sensitivity;
    }
}
