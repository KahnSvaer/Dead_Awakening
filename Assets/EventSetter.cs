using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSetter : MonoBehaviour
{
    EnemyAttack enemyAttack;

    void Start()
    {
        enemyAttack = GetComponentInParent<EnemyAttack>();
    }

    public void SetTarget(Transform target) //Using this so that maybe we can even make it attack enviroment affecting the health Class
    {
        // this.target = target;
    }

    public void AttackEvent() //Would be called from EventSetter
    {
        if (enemyAttack == null) return;
        enemyAttack.ProcessAttack();
    }

}
