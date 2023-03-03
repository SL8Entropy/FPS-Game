using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;
    public GameObject player;
    public float projectileSpeed;
    public float knockback;
    public Vector3 targetPosition;
    public Vector3 projectileDir;
    Collider playerColl, projectileColl;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        targetPosition = player.transform.position;
        projectileDir = (targetPosition - transform.position).normalized * projectileSpeed;



        playerColl = player.GetComponent<Collider>();
        projectileColl = GetComponent<Collider>();
        Debug.Log(targetPosition);
    }

    void FixedUpdate()
    {
        transform.position += projectileDir * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetPosition) > 30)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        player.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        Vector3 knockbackDirection =(player.transform.position - transform.position).normalized*knockback;
        player.gameObject.GetComponent<PlayerMotor>().knockbackVelocity += knockbackDirection;

        Destroy(gameObject);

    }
}
