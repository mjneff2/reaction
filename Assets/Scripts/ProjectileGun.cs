﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileGun : MonoBehaviour
{
    private AudioSource audioData;
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
    private bool buttonPressed;

    public void Awake()
    {
        audioData = GetComponent<AudioSource>();
        player = transform.root.gameObject;
        rb = player.GetComponent<Rigidbody>();
        camera1 = player.GetComponentInChildren<Camera>();
    }

    public void Update()
    {
        if (buttonPressed)
        {
            shoot(weaponForce, bulletLifetime);
        }
    }

    public void shoot(float bulletForce, float bulletLifetime) {
        if (Time.time > lastShot + timeBetweenShots)
        {
            var forward = camera1.transform.forward;
            forward.Normalize();
            rb.AddForce(forward * -weaponForce);
            lastShot = Time.time;
            forward = forward * player.GetComponent<SphereCollider>().radius;
            audioData.Play(0);
            GameObject bullet = Instantiate(projectile, player.transform.position + forward * 1.5f, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().mass = bulletMass;
            bullet.GetComponent<Rigidbody>().AddForce(forward * bulletForce);
            bullet.GetComponent<BulletImpact>().bulletDamage = bulletDamage;
            bullet.GetComponent<BulletImpact>().shooter = transform.root.gameObject;
            bullet.transform.localScale = bulletScale;
            Destroy(bullet, bulletLifetime);
        }
    }

    public void OnFireStart()
    {
        buttonPressed = true;
    }

    public void OnFireEnd()
    {
        buttonPressed = false;
    }
}
