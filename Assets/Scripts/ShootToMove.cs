using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToMove : MonoBehaviour
{
    public Rigidbody rb;
    public Camera camera1;
    public float timeBetweenShots = 2.0f;
    public float lastShot = 0;
    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera1 = GetComponentInChildren<Camera>();
    }

    public void FixedUpdate() {
        var forward = camera1.transform.forward;
        forward.Normalize();
        if (Input.GetButton("Fire1") && Time.time > lastShot + timeBetweenShots) {
            rb.AddForce(forward * -300.0f);
            lastShot = Time.time;
            shoot();
        }
    }

    void shoot() {
        //ToDo
    }
}