using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weopon : MonoBehaviour
{
    // Start is called before the first frame update    

    [SerializeField] InputAction shoot;
    [SerializeField] [Range(1,3)] [Tooltip("Mode of Fire\n 1->Tap\n 2->Burst\n 3->Automatic")]int fireMode = 1 ;
    [SerializeField] int bulletDamage = 10; //Maybe add headShot Damage next

    Camera mainCamera;


    private void OnEnable() {
        shoot.Enable();
    }

    private void OnDisable() {
        shoot.Disable();
    }

    private void Start() {
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessShoot();
    }

    private void ProcessShoot()
    {
        bool toShoot;
        //assuming mode is 1 for now
        toShoot = shoot.WasPerformedThisFrame();
        if(toShoot)
        {
            RaycastHit hitObject;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hitObject))
            {
                GameObject target = hitObject.transform.gameObject;
                if (target.GetComponent<EnemyHealth>() == null) {return;}
                ShootEnemy(target);
            }
        }
    }

    private void ShootEnemy(GameObject target)
    {
        Debug.Log("HIt: " + target.name);
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        enemyHealth.DecreaseHealth(bulletDamage);
    }
}
