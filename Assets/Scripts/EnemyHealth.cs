using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;

    int health;
    public int Health{get{return health;}} //getter to get heatlh


    private void Start() {
        health = maxHealth;
    } //Maybe use OnEnable if we are planning to use ObjectPool

    public void DecreaseHealth(int damage)
    {
        health -= damage;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if(health<=0)
        {
            gameObject.SetActive(false);
        }
    }
}
