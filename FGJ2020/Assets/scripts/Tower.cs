using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I'm working");
        AddHp(5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCOllisionEnter2D(Collision2D collision)
    {
        AddHp(5);

        if (collision.gameObject.tag == "player")
        {
            AddHp(10);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AddHp(5);
        }
    }

    // void OnTriggerStay2D(Collider2D collider)
    // {
    //     AddHp(1);
    // }


    private void AddHp(int hp)
    {
        health += hp;
        Debug.Log(health);
    }
}
