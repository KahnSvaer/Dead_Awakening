using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100; 
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;
        if(currentHealth<=0)
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        PlayerDeathHandler playerDeathHandler = GetComponent<PlayerDeathHandler>();
        playerDeathHandler.HandleDeath();
    }
}
