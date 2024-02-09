using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update    

    [SerializeField] InputAction shoot;
    [SerializeField] [Range(1,3)] [Tooltip("Mode of Fire\n 1->Tap\n 2->Burst\n 3->Automatic")]int fireMode = 1 ;
    [SerializeField] int bulletDamage = 10; //Maybe add headShot Damage next
    [SerializeField] ParticleSystem[] hitEffectVFX;
    
    Transform vfxContainer;
    Camera mainCamera;
    ParticleSystem muzzleFlashVFX;


    private void OnEnable() {
        shoot.Enable();
    }

    private void OnDisable() {
        shoot.Disable();
    }

    private void Start() {
        mainCamera = FindObjectOfType<Camera>();
        muzzleFlashVFX = GetComponentInChildren<ParticleSystem>();
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
        toShoot = shoot.WasPerformedThisFrame(); //This is only for 1 firing mode for the rest they would be much different
        if(toShoot)
        {
            ProcessRaycast();
            MuzzleParticlePlay();
        }
    }

    private void MuzzleParticlePlay()
    {
        muzzleFlashVFX.Play();
    }
    private void ProcessRaycast()
    {
        RaycastHit hitObject;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hitObject))
        {
            Transform target = hitObject.transform;
            bool isZombie = target.parent.GetComponent<EnemyHealth>() != null; //checking if present or not
            ShootWeapon(hitObject, isZombie);
        }
    }

    private void ShootWeapon(RaycastHit hitObject, bool isZombie)
    {
        Transform target = hitObject.transform;
        int hitEffectIndex;
        if (isZombie)
        {
            hitEffectIndex = 1;
            vfxContainer = target.parent.GetChild(0); //Getting the sibling of the collider
            
            EnemyHealth enemyHealth = target.GetComponentInParent<EnemyHealth>();
            enemyHealth.DecreaseHealth(bulletDamage);
        }
        else
        {
            hitEffectIndex = 0;
            vfxContainer =  GameObject.FindWithTag("VFXContainer").transform;
        }

        ParticleSystem particle = Instantiate(hitEffectVFX[hitEffectIndex], hitObject.point, Quaternion.LookRotation(hitObject.normal), vfxContainer);
        Destroy(particle.gameObject,3f);
        
        
    }
}
