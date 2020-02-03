using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float liftspeed = 7f;
    public float throwSpeed = 15f;
    public Transform carryPosition;
    public Transform throwpointUp;
    public Transform throwpointDown;
    public Transform throwpointLeft;
    public Transform throwpointRight;
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastMove;
    private GameObject nostettuPala;
    private bool isMoving = false;
    private bool isLifting = false;
    private bool isCarrying = false;
    public List<GameObject> nostoJono = new List<GameObject>();


    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = false;

        // x and y movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            isMoving = true;
            lastMove = new Vector2(movement.x, movement.y);
        }

        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("PlayerMoving", isMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);

        if (Input.GetButtonDown("Fire1"))
        {

            if (nostoJono.Count > 0) // nostettava != null
            {
                if (!isLifting)
                {
                    {
                        isLifting = true;
                        nostettuPala = nostoJono[0];
                    }
                }
                else
                {
                    throwPart();
                }
            }

        }

        if (isLifting)
        {
            liftObject();
        }

        // Turning towards mouse position
        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger triggered");
        if (other.gameObject.tag == "nostettava")
        {
            //nostettava = other.gameObject;
            nostoJono.Add(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Törmäys!");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Exited trigger");
        if (other.gameObject.tag == "nostettava")
        {
            nostoJono.Remove(other.gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void liftObject()
    {
        // Debug.Log("Lifting object");
        //Debug.Log("Nostojono counti is: " + nostoJono.Count);
        float step = liftspeed * Time.deltaTime;
        nostettuPala.transform.position = Vector2.MoveTowards(nostettuPala.transform.position, carryPosition.position, step);

    }

    public void throwPart()
    {
        // Debug.Log("Throwing part");
        PartController pc = nostettuPala.gameObject.GetComponent<PartController>();
        nostoJono.Remove(nostettuPala);
        isLifting = false;
        //Debug.Log(lastMove);
        if (lastMove.x == 0 && lastMove.y == 1)
        {
            pc.throwPart(throwpointUp, throwSpeed);
        }
        if (lastMove.x == 0 && lastMove.y == -1)
        {
            pc.throwPart(throwpointDown, throwSpeed);
        }
        if (lastMove.x == -1 && lastMove.y == 0)
        {
            pc.throwPart(throwpointLeft, throwSpeed);
        }
        if (lastMove.x == 1 && lastMove.y == 0)
        {
            pc.throwPart(throwpointRight, throwSpeed);
        }
    }
}
