using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponContainer : MonoBehaviour
{
    [SerializeField]InputAction mouseUp;
    [SerializeField]InputAction mouseDown;

    int weaponIndex = 0;

    private void Start() {
        SetupWeapons();
    }

    private void SetupWeapons()
    {
        foreach(Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnEnable() {
        mouseUp.Enable();
        mouseDown.Enable();
    }

    private void OnDisable() {
        mouseUp.Disable();
        mouseDown.Disable();
    }

    
    private void Update()
    {
        ProcessGunSwitch();
    }

    private void ProcessGunSwitch()
    {
        if (mouseUp.WasPressedThisFrame())
        {
            ChangeWeapon(true);
        }
        else if (mouseDown.WasPressedThisFrame())
        {
            ChangeWeapon(false);
        }
    }

    
    private void ChangeWeapon(bool toNext)
    {
        int totalWeapons = transform.childCount;

        transform.GetChild(weaponIndex).gameObject.SetActive(false);
        if(toNext) {weaponIndex++;}
        else {weaponIndex--;}

        weaponIndex = (weaponIndex+totalWeapons) % totalWeapons; //Kinda a workaround not sure why negative numbers are not working

        transform.GetChild(weaponIndex).gameObject.SetActive(true);
    }
}
