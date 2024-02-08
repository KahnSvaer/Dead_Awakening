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
    Animator animator;
    float distanceToTarget = Mathf.Infinity;

    bool isProvoked;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
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
        animator.SetBool("Attack",true);
    }

    void ChaseTarget()
    {
        animator.SetBool("Attack",false);
        animator.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }


    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,chaseRange);
    }
}
