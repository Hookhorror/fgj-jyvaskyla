using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // public GameObject hitEffect;
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }


    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(gameObject);
        Debug.Log("Something was hit!");
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // Spawns the hit effect when bullet collides
    //     GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //     // Destroys the effect after given time
    //     Destroy(effect, 1);
    //     Destroy(gameObject);
    //     Destroy(gameObject, 1);
    // }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     // Spawns the hit effect when bullet collides
    //     GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //     // Destroys the effect after given time
    //     Destroy(effect, 1);
    //     Destroy(gameObject);
    //     Destroy(gameObject, 1);
    // }
}
