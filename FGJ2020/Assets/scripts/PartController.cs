using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{    
    public Animator animator;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void throwPart(Vector2 direction)
    {
        Debug.Log(direction);
        animator.SetFloat("FacingX", direction.x);
        animator.SetFloat("FacingY", direction.y);
        animator.SetTrigger("Throw");

    }


}
