using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{

    private float throwspeed;
    private Vector2 throwTarget;
    private bool isThrowing = false;

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
    }

}
