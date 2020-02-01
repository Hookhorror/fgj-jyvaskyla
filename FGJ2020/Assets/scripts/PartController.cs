using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{

    public float throwspeed = 5f;
    private Transform throwTarget;


    public void throwPart(Transform target)
    {
        GameObject empty = new GameObject();
        empty.transform.position = target.position;
        throwTarget = empty.transform;
        Destroy(empty);
    }

    void Update()
    {
        if (throwTarget != null)
        {
            float step = throwspeed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, throwTarget.position, step);

            if ((gameObject.transform.position - throwTarget.position).sqrMagnitude < 0.01f)
            {
                throwTarget = null;
            }
        }



    }

}
