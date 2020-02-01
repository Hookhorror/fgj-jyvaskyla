using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    // Vector2 mousePos;
    private GameObject nostettava;
    public float liftspeed = 7f;
    public Transform carryPosition;
    private bool lifting;


    // Update is called once per frame
    void Update()
    {
        // x and y movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1") && nostettava)
        {
            lifting = true;            
        }

        if (lifting){
            liftObject();
        }
        
        // Turning towards mouse position
        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.tag=="nostettava")
        {
            nostettava = other.gameObject;            
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if(other.gameObject.tag=="nostettava")
        {
            nostettava = null;            
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

    public void liftObject(){
        float step = liftspeed * Time.deltaTime;
        nostettava.transform.position = Vector2.MoveTowards(nostettava.transform.position, carryPosition.position, step);
    }
}
