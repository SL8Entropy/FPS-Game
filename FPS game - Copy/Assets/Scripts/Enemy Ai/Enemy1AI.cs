using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AI : GroundEnemyBaseScript
{
    
    protected override void chasePlayer()
    {
        navMeshAgent.SetDestination(player.position);
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));


    }

    protected override void attackCode()
    {
        player.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
    }
}
