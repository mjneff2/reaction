using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public Slider healthBar;
    private GameObject playerSpawner;
    private int lastSpawn = -1;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerSpawner = GameObject.Find("PlayerSpawner");
    }
    
    void die() {
        gameObject.transform.position = playerSpawner.transform.GetChild(0).GetChild(getNewSpawn()).position;
        currentHealth = maxHealth;
        healthBar.value = currentHealth / maxHealth;
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
