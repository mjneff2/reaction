using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public Slider healthBar;
    public CanvasGroup deathTint;
    public GameObject weapons;
    private GameObject playerSpawner;
    private int lastSpawn = -1;
    private bool dead;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        currentHealth = maxHealth;
        playerSpawner = GameObject.Find("PlayerSpawner");
    }
    
    void die() {
        dead = true;
        deathTint.alpha = 1;
        weapons.SetActive(false);
        //Disable visuals
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void takeDamage(float damage, GameObject shooter) {
        currentHealth -= damage;
        healthBar.value = currentHealth / maxHealth;
        if (currentHealth < 1)
        {
            die();
            shooter.GetComponent<KillCounter>().killCount++;
        }
    }

    public void OnRespawn() {
        if (dead) {
            //Disable children
            weapons.SetActive(true);
            //Disable visuals
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<SphereCollider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            dead = false;
            deathTint.alpha = 0;
            gameObject.transform.position = playerSpawner.transform.GetChild(0).GetChild(getNewSpawn()).position;
            currentHealth = maxHealth;
            healthBar.value = currentHealth / maxHealth;
        }
    }

    private int getNewSpawn()
    {
        int newSpawn = Random.Range(0, 4);
        while (newSpawn == lastSpawn)
        {
            newSpawn = Random.Range(0, 4);
        }
        return newSpawn;
    }
}
