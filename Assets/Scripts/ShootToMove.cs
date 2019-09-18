using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToMove : MonoBehaviour
{
    public Rigidbody rb;
    public Camera camera1;
    public GameObject projectile;
    public float timeBetweenShots = 1.0f;
    public float lastShot = 0;
    public float reboundVelocity = 450.0f;
    public float bulletVelocity = 75.0f;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera1 = GetComponentInChildren<Camera>();
    }

    public void FixedUpdate() {
        var forward = camera1.transform.forward;
        forward.Normalize();
        if (Input.GetButton("Fire1") && Time.time > lastShot + timeBetweenShots) {
            shoot();
            rb.AddForce(forward * -reboundVelocity);
            lastShot = Time.time;
        }
    }

    void shoot() {
        var forward = camera1.transform.forward;
        forward.Normalize();
        GameObject bullet = Instantiate(projectile, transform.position + forward, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(forward * bulletVelocity);
    }
}