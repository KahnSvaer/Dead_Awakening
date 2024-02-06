using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeopenContainer : MonoBehaviour
{
    [SerializeField]InputAction mouseUp;
    [SerializeField]InputAction mouseDown;

    int weopenIndex = 0;

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
            ChangeWeopen(true);
        }
        else if (mouseDown.WasPressedThisFrame())
        {
            ChangeWeopen(false);
        }
    }

    
    private void ChangeWeopen(bool toNext)
    {
        int totalWeopons = transform.childCount;

        transform.GetChild(weopenIndex).gameObject.SetActive(false);
        if(toNext) {weopenIndex++;}
        else {weopenIndex--;}

        weopenIndex = (weopenIndex+totalWeopons) % totalWeopons; //Kinda a workaround not sure why negative numbers are not working

        transform.GetChild(weopenIndex).gameObject.SetActive(true);
    }
}
