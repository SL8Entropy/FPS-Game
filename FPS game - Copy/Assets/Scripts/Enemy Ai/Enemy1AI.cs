using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AI : GroundEnemyBaseScript
{
    public float damage;
    public float projectileSpeed;
    public GameObject projectile;
    public float knockback;
    public float stun;

    protected override void chasePlayer()
    {
        navMeshAgent.SetDestination(player.position);
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    protected override void attackCode()
    {

        Instantiate(projectile, transform.GetChild(0).position, projectile.transform.rotation);

        projectile.GetComponent<EnemyProjectile>().damage = damage;
        projectile.GetComponent<EnemyProjectile>().projectileSpeed = projectileSpeed;
        projectile.GetComponent<EnemyProjectile>().knockback = knockback;
        projectile.GetComponent<EnemyProjectile>().stun = stun;


        //projectile.GetComponent<projectileScript>().projectileSpeed = projectileSpeed
        //same for targetPosition.
    }
}
