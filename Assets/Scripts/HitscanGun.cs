using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitscanGun : MonoBehaviour
{
    private AudioSource audioData;
    private GameObject player;
    private Rigidbody rb;
    private Camera camera1;
    private LineRenderer laser;
    public int barrelIndex;
    private float effectDisplayTime = 0.1f;
    private float lastShot = 0;
    public float timeBetweenShots;
    public float weaponForce;
    public float bulletDamage;
    private bool buttonPressed;

    public void Awake()
    {
        audioData = GetComponent<AudioSource>();
        player = transform.root.gameObject;
        rb = player.GetComponent<Rigidbody>();
        camera1 = player.GetComponentInChildren<Camera>();
        laser = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        if (buttonPressed)
        {
            shoot();
        }

        if (Time.time >= lastShot + effectDisplayTime)
        {
            disableEffects();
        }
    }

    public void shoot()
    {
        if (Time.time > lastShot + timeBetweenShots)
        {
            var forward = camera1.transform.forward;
            forward.Normalize();
            lastShot = Time.time;
            audioData.Play(0);
            laser.SetPosition(0, transform.GetChild(barrelIndex).position);
            RaycastHit hit;
            if (Physics.Raycast(camera1.transform.position, forward, out hit))
            {
                Debug.Log(hit.transform.name);
                laser.enabled = true;
                laser.SetPosition(1, hit.point);
                PlayerHealth playerHealth = hit.transform.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.takeDamage(bulletDamage, transform.root.gameObject);
                }
            }
            rb.AddForce(forward * -weaponForce);
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

    public void disableEffects()
    {
        laser.enabled = false;
    }
}
