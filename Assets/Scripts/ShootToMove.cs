using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToMove : MonoBehaviour
{
    private Rigidbody rb;
    private Camera camera1;
    public GameObject projectile;
    public float timeBetweenShots;
    private float lastShot = 0;
    public float weaponForce;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera1 = GetComponentInChildren<Camera>();
    }

    public void FixedUpdate() {
        var forward = camera1.transform.forward;
        forward.Normalize();
        if (Input.GetButton("Fire1") && Time.time > lastShot + timeBetweenShots) {
            shoot(weaponForce, 10.0f);
            rb.AddForce(forward * -weaponForce);
            lastShot = Time.time;
        }
    }

    public void shoot(float bulletForce, float bulletLifetime) {
        var forward = camera1.transform.forward;
        forward.Normalize();
        forward = forward * GetComponent<SphereCollider>().radius;
        GameObject bullet = Instantiate(projectile, transform.position + forward, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(forward * bulletForce);
        Destroy(bullet, bulletLifetime);
    }
}