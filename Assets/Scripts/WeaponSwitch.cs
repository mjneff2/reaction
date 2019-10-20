using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public int currentWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            if (currentWeapon >= transform.childCount - 1) {
                currentWeapon = 0;
            } else {
                currentWeapon++;
            }
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            if (currentWeapon >= transform.childCount - 1) {
                currentWeapon = 0;
            } else {
                currentWeapon++;
            }
        }
        
        if (previousWeapon != currentWeapon) {
            selectWeapon();
        }
    }

    void selectWeapon() {
        int k = 0;
        foreach (Transform weapon in transform) {
            if (k == currentWeapon) {
                weapon.gameObject.SetActive(true);
            } else {
                weapon.gameObject.SetActive(false);
            }
            k++;
        }
    }
}
