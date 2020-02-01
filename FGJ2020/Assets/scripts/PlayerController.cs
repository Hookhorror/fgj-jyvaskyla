using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float moveSpeed = 5f;
  public float liftspeed = 7f;
  public Transform carryPosition;
  public Animator animator;
  private Rigidbody2D rb;
  private Vector2 movement;
  private GameObject nostettava;
  private bool lifting = false;

  void Awake()
  {
    rb = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    // x and y movement
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    animator.SetFloat("Horizontal", movement.x);
    animator.SetFloat("Vertical", movement.y);
    animator.SetFloat("Speed", movement.sqrMagnitude);

    if (Input.GetButtonDown("Fire1"))
    {
      if (!lifting)
      {
        {
          lifting = true;
        }
      }
      else
      {
        lifting = false;
      }

    }

    if (lifting)
    {
      liftObject();
    }

    // Turning towards mouse position
    // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "nostettava")
    {
      nostettava = other.gameObject;
      Debug.Log(nostettava);
    }
  }
  void FixedUpdate()
  {
    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    // Turning
    // Vector2 lookDir = mousePos - rb.position;
    // float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    // rb.rotation = angle;
  }

  public void liftObject()
  {
    float step = liftspeed * Time.deltaTime;
    nostettava.transform.position = Vector2.MoveTowards(nostettava.transform.position, carryPosition.position, step);
  }
}
