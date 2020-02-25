using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]
    public float maxHp = 100f;
    public float hp;
    public float shotHpCost = 5f;
    public float range;
    public float maxFireRate = 1;
    public float fireRate;
    public float brokenFirerate = 0.5f;
    public float fireCountdown = 0f;
    public float amountRepaired = 10f;
    public Animator animator;

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
        //Debug.Log("Firerate is: " + fireRate);
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

        UpdateFireRate();

        animator.SetFloat("HP", hp);
    }

    void Shoot()
    {
        // Spawn a bullet
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        
        hp -= shotHpCost;
        if (hp < 0) hp = 0;

        if (bullet != null)
            bullet.Seek(target);

        //Debug.Log("Shots fired!");
    }

    void Repair(float hp_)
    {
        if ((hp + hp_) > maxHp) hp = maxHp;
        else hp += hp_;
        Debug.Log("Raised HP by " + hp_ + ", HP is now " + hp + "/" + maxHp);
        animator.SetFloat("HP", hp);
    }


    void UpdateFireRate()
    {
        if (hp < 50f)
        {
            // fireRate = maxFireRate * (hp / 100) + 0.1f;
            // Debug.Log("Firerate is: " + fireRate);
            fireRate = brokenFirerate;
        }
        else fireRate = maxFireRate;
    }

    // void OnCOllisionEnter2D(Collision2D collision)
    // {
    //     AddHp(5);

    //     if (collision.gameObject.tag == "player")
    //     {
    //         AddHp(10);
    //     }
    // }


    void Korjaa(Collider2D collision)
    {

        if (collision.CompareTag("nostettava") && hp < maxHp)
        {
            //haetaan palikan skripti
            PartController pc = collision.gameObject.GetComponent<PartController>();
            if (pc != null)
            {
                //jos skripti löytyi niin:
                if (pc.OnkoKyydissaGet())
                {
                    //ei tehdä mitään kun palikka on jollain kyydissä
                    return;
                }

            }
            Repair(pc.repairamount);
            //Debug.Log("Firerate is: " + fireRate);
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Korjaa(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Korjaa(collision);

    }

    // void OnTriggerStay2D(Collider2D collider)
    // {
    //     AddHp(1);
    // }
}
