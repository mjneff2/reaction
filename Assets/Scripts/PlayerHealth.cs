using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public Slider healthBar;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 1) {
            die();
        }
    }
    
    void die() {
        gameObject.transform.position = originalPos;
        currentHealth = maxHealth;
        healthBar.value = currentHealth / maxHealth;
    }

    public void takeDamage(float damage) {
        currentHealth -= damage;
        healthBar.value = currentHealth / maxHealth;
    }

}
