using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth = 0;
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
            gameObject.transform.position = originalPos;
            currentHealth = maxHealth;
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Bullet") {
            currentHealth -= 20;
            Destroy(col.gameObject);
        }
    }
}
