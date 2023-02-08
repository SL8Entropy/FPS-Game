using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;
    public GameObject player;
    public float projectileSpeed;
    public Vector3 targetPosition;
    public Vector3 projectileDir;
    Collider playerColl, projectileColl;

    // Start is called before the first frame update
    void Awake()
    {
        projectileDir = targetPosition - transform.position;
        player = GameObject.Find("Player");


        playerColl = player.GetComponent<Collider>();
        projectileColl = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += projectileDir.normalized * projectileSpeed * Time.deltaTime;
        

    }
    private void OnTriggerEnter(Collider other)
    {
        player.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
