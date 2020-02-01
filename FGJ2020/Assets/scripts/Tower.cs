﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]
    public int health;
    public float range;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Rigidbody2D rb;
    public float turnSpeed = 5f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    // public Transform partToRotate;

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

        if (shortestDistance > range)
            target = null;
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
        // Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // partToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);
        Vector2 rotation = lookRotation.eulerAngles;
        rb.rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        // Spawn a bullet
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();


        if (bullet != null)
            bullet.Seek(target);

        Debug.Log("Shots fired!");
    }

    // void OnCOllisionEnter2D(Collision2D collision)
    // {
    //     AddHp(5);

    //     if (collision.gameObject.tag == "player")
    //     {
    //         AddHp(10);
    //     }
    // }


    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Player"))
    //     {
    //         AddHp(5);
    //     }
    // }

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
