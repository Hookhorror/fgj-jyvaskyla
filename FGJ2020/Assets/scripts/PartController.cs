using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{

    private float throwspeed;
    private Vector2 throwTarget;
    private bool isThrowing = false;
    // public Rigidbody2D rb;

    public void throwPart(Transform target, float speed)
    {                
        throwspeed = speed;
        throwTarget = new Vector2(target.transform.position.x, target.transform.position.y);
        //Debug.Log(throwTarget);
        isThrowing = true; 
    }

    void Update()
    {
        if (isThrowing)
        {
            //Debug.Log("Heittää kokoajan");
            float step = throwspeed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, throwTarget, step);

            if (((Vector2)gameObject.transform.position - throwTarget).sqrMagnitude < 0.01f)
            {                
                isThrowing = false;
            }
        }
        // if (Input.GetButton("Fire1"))
        // {
        //     rb.AddForce(transform.right * 10f);
        // }
    }

    void OnTriggerEnter2d (Collider2D hitInfo)
    {
        Debug.Log("Trigger entered, other is " + hitInfo.name);
    }

    void OnCollisionEnter2d (Collision2D hitInfo)
    {
        Debug.Log("Osuma!" + hitInfo.gameObject.name);
    }

}
