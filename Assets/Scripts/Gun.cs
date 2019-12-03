using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private Camera camera1;
    private float lastShot = 0;
    public GameObject projectile;
    public float timeBetweenShots;
    public float weaponForce;
    public Vector3 bulletScale;
    public float bulletMass;
    public float bulletLifetime = 20f;
    public float bulletDamage = 20f;
    public string shootButton;

    public void Awake()
    {
        shootButton = transform.root.gameObject.GetComponent<ControlStrings>().shootButton;
        player = transform.root.gameObject;
        rb = player.GetComponent<Rigidbody>();
        camera1 = player.GetComponentInChildren<Camera>();
    }

    public void FixedUpdate() {
        /*var forward = camera1.transform.forward;
        forward.Normalize();
        if ((Input.GetButton(shootButton) || Input.GetAxis(shootButton) > 0f) && Time.time > lastShot + timeBetweenShots) {
            shoot(weaponForce, bulletLifetime);
            rb.AddForce(forward * -weaponForce);
            lastShot = Time.time;
        }*/
    }

    public void shoot(float bulletForce, float bulletLifetime) {
        if (Time.time > lastShot + timeBetweenShots)
        {
            var forward = camera1.transform.forward;
            forward.Normalize();
            rb.AddForce(forward * -weaponForce);
            lastShot = Time.time;
            forward = forward * player.GetComponent<SphereCollider>().radius;
            GameObject bullet = Instantiate(projectile, player.transform.position + forward * 1.5f, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().mass = bulletMass;
            bullet.GetComponent<Rigidbody>().AddForce(forward * bulletForce);
            bullet.GetComponent<BulletImpact>().bulletDamage = bulletDamage;
            bullet.transform.localScale = bulletScale;
            Destroy(bullet, bulletLifetime);
        }
    }

    public void OnFire()
    {
        Debug.Log("Fire!");
        shoot(weaponForce, bulletLifetime);
    }
}
