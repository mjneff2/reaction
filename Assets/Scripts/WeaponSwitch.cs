using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public int currentWeapon = 0;
    //public string switchAxis;
    public float switchCooldown = 0.2f;
    private float lastSwitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //switchAxis = transform.root.gameObject.GetComponent<ControlStrings>().switchAxis;
        //Debug.Log(switchAxis);
        selectWeapon();
    }

    // Update is called once per frame
    /*void Update()
    {
        int previousWeapon = currentWeapon;
        if (Time.time - lastSwitch > switchCooldown) {
            if (Input.GetAxis(switchAxis) > 0f) {
                if (currentWeapon >= transform.childCount - 1) {
                    currentWeapon = 0;
                } else {
                    currentWeapon++;
                }
            } else if (Input.GetAxis(switchAxis) < 0f) {
                if (currentWeapon <= 0) {
                    currentWeapon = transform.childCount - 1;
                } else {
                    currentWeapon--;
                }
            }
        }
        if (previousWeapon != currentWeapon) {
            selectWeapon();
            lastSwitch = Time.time;
        }
    }*/

    void OnSwitchLeft()
    {
        int previousWeapon = currentWeapon;
        if (currentWeapon >= transform.childCount - 1)
        {
            currentWeapon = 0;
        }
        else
        {
            currentWeapon++;
        }
        if (previousWeapon != currentWeapon)
        {
            selectWeapon();
            lastSwitch = Time.time;
        }
    }

    void OnSwitchRight()
    {
        int previousWeapon = currentWeapon;
        if (currentWeapon <= 0)
        {
            currentWeapon = transform.childCount - 1;
        }
        else
        {
            currentWeapon--;
        }
        if (previousWeapon != currentWeapon)
        {
            selectWeapon();
            lastSwitch = Time.time;
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
