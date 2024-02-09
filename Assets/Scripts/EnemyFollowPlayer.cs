using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] float chaseRange = 5; 
    [SerializeField] float turnSpeed;

    [Tooltip("Editor only")][SerializeField] bool enableGizmos = false;

    
    Transform target;
    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;

    bool isProvoked;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
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
        CheckAwareness();
    }

    private void CheckAwareness()
    {
        if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void Agroed()
    {
        isProvoked = true;
    }


    private void EngageTarget()
    {
        FaceTarget();
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

    private void ChaseTarget()
    {
        animator.SetBool("Attack",false);
        animator.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction =  -1*(transform.position - target.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }


    private void OnDrawGizmosSelected() {
        if (enableGizmos)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,chaseRange);
        }
    }
}
