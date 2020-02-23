using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{

    private float throwspeed;
    private Vector2 throwTarget;
    private bool isThrowing = false;
    private bool onkoKyydissa = false;

    public void throwPart(Transform target, float speed)
    {                
        throwspeed = speed;
        throwTarget = new Vector2(target.transform.position.x, target.transform.position.y);
        //Debug.Log(throwTarget);
        isThrowing = true;
        onkoKyydissa = false;
    }

    public void otettiinKyytiin()
    {
        onkoKyydissa = true;
    }
    public bool onkoKyydissaGet()
    {
        return onkoKyydissa;
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
    void OnDestroy()
    {
        //TODO lisää tähän se että vaihdeta
    }

}
