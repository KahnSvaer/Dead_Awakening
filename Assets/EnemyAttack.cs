using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] int damage;

    public void ProcessAttack()
    {
        Debug.Log("Attacking Player");
    }
}
