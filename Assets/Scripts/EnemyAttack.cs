using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 20;

    Transform target;
    PlayerHealth playerHealth;
    
    private void Start() {
        target = FindObjectOfType<PlayerHealth>().transform;
        playerHealth = target.GetComponent<PlayerHealth>();
    }

    public void ProcessAttack()
    {
        playerHealth.DecreaseHealth(damage);
    }
}
