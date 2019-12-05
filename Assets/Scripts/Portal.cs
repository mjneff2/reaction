using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject teleportTo;
    public float lastCollision = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"  && Time.time > lastCollision + 1)
        {
            collision.gameObject.transform.position = teleportTo.transform.GetChild(0).position;
            teleportTo.GetComponent<Portal>().lastCollision = Time.time;
            lastCollision = Time.time;
        }
    }
}
