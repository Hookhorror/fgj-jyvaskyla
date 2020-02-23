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
    private bool playerMoving = false;
    private bool playerLifting = false;
    public List<GameObject> nostoJono = new List<GameObject>();


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

        //Palikkaa ei ole enää kädessä, mutta se aiemmin on ollut. Tämä tapahtuu jos palikka on tuhottu kädessä ollessa.
        if (nostettuPala == null && playerLifting)
        {
            //vaihdetaan siis että enää ei ole palikkaa kädessä
            playerLifting = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {

            if (nostoJono.Count > 0) // nostettava != null
            {
                if (!playerLifting)
                {
                    {
                        playerLifting = true;
                        nostettuPala = nostoJono[0];
                        PartController pc = nostettuPala.gameObject.GetComponent<PartController>();
                        pc.otettiinKyytiin();
                    }
                }
                else if(nostoJono[0]== null)
                {
                    playerLifting = false;
                }
                else
                {
                    throwPart();
                }
            }

        }

        if (playerLifting && nostoJono.Count > 0)
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

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited trigger");
        if (other.gameObject.tag == "nostettava")
        {
            nostoJono.Remove(other.gameObject);
        }
    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     Debug.Log("Exited trigger");
    //     if (other.gameObject.tag == "nostettava")
    //     {

    //     }
    //     else nostoJono.Remove(other.gameObject);
    // }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void liftObject()
    {
        // Debug.Log("Lifting object");
        Debug.Log("Nostojono counti is: " + nostoJono.Count);
        float step = liftspeed * Time.deltaTime;
        nostettuPala.transform.position = Vector2.MoveTowards(nostettuPala.transform.position, carryPosition.position, step);

    }

    public void throwPart()
    {
        // Debug.Log("Throwing part");
        if (nostettuPala == null)
        {
            playerLifting = false;
            return;
        }
        PartController pc = nostettuPala.gameObject.GetComponent<PartController>();
        nostoJono.Remove(nostettuPala);
        playerLifting = false;
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
