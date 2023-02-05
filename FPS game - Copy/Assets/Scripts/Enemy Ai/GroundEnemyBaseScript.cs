using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyBaseScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Attacking
    public float timeBetweenAttacks;
    public float attackTime;
    bool alreadyAttacked;

    //states
    public float attackRange;
    public bool playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Debug.Log("YES");
        //check if player is in attack range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange) chasePlayer();
        if (playerInAttackRange) attackPlayer();

    }



    protected virtual void chasePlayer()
    {

    }
    private void attackPlayer()
    {
        navMeshAgent.SetDestination(transform.position);
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        if (!alreadyAttacked)
        {
            //attack code here
            Invoke(nameof(attackCode),attackTime);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    protected virtual void attackCode()
    {

    }
}
