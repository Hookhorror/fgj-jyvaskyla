using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health;
    public Transform target;
    public float range = 2f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public Rigidbody2D rb;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                // Debug.Log("New enemy detected: " + nearestEnemy.name);
            }

        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector2 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector2 rotation = lookRotation.eulerAngles;
        rb.rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
    }

    void OnCOllisionEnter2D(Collision2D collision)
    {
        AddHp(5);

        if (collision.gameObject.tag == "player")
        {
            AddHp(10);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AddHp(5);
        }
    }

    // void OnTriggerStay2D(Collider2D collider)
    // {
    //     AddHp(1);
    // }


    private void AddHp(int hp)
    {
        health += hp;
        Debug.Log(health);
    }
}
