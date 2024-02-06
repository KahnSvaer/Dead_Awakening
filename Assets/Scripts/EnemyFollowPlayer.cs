using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5; 
    
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    bool isProvoked;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        distanceToTarget = Vector3.Distance(transform.position,target.position);
    }

    void Update()
    {
        FollowTarget();
    }


    private void FollowTarget()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }


    private void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance){
        ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance){
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        Debug.Log("Being Attacked by Zombie!");
    }

    void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }


    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,chaseRange);
    }
}
