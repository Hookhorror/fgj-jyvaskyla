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
  private Vector2 lastMove;
  private GameObject nostettava;
  private bool playerMoving = false;
  private bool playerLifting = false;

  void Awake()
  {
    rb = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    playerMoving = false;

    // x and y movement
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    if (movement.x != 0 || movement.y != 0)
    {
      playerMoving = true;
      lastMove = new Vector2(movement.x, movement.y);
    }

    animator.SetFloat("MoveX", movement.x);
    animator.SetFloat("MoveY", movement.y);
    animator.SetBool("PlayerMoving", playerMoving);
    animator.SetFloat("LastMoveX", lastMove.x);
    animator.SetFloat("LastMoveY", lastMove.y);

    if (Input.GetButtonDown("Fire1"))
    {
      if (nostettava != null)
      {
        Debug.Log("nostettava != null");
        if (!playerLifting)
        {
          Debug.Log("lift");
          playerLifting = true;
        }
        else
        {
          playerLifting = false;
          PartController partController = nostettava.GetComponent<PartController>();
          partController.throwPart(lastMove);          
          nostettava = null;
        }
      }

    }

    if (playerLifting)
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
      Debug.Log("nostettava");
      nostettava = other.gameObject;
    }
  }
  void FixedUpdate()
  {
    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
  }

  public void liftObject()
  {
    Debug.Log("Nostaa");
    float step = liftspeed * Time.deltaTime;
    nostettava.transform.position = Vector2.MoveTowards(nostettava.transform.position, carryPosition.position, step);
  }
}
