using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vihu : MonoBehaviour
{
    [Header("vihun muuttujat")]
    public int hp = 100;
    [Header("Nopeudet")]
    [Tooltip("1.0 on normaali")]
    public float speedScale = 1.0f;
    [Tooltip("1.0 on normaali")]
    public float speedScaleWhenSlowed = 0.5f;
    [Header("Näille tekee erilaisia vihuja")]
    public bool isImmuneToSlow = false;

    private Rigidbody2D rb;
    private bool isSlowed = false;

    [Header("Kohde minne vihu on menossa")]
    [Tooltip("Pitäisi olla ensimmäinen waypoint")]

    //public VihuWaypoint nykyinenKohde;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //tekee vahinkoa vihuun halutun maaran
    void damage (int maara)
    {
        if (hp >= maara)
        {
            //hp:ta on enemman kuin mita on tulossa, niin otetaan vahinkoa
            hp = hp - maara;
            //TODO: paivita sprite jos tarvetta
        }
        else
        {
            hp = 0;
            kuole();
        }
    }

    //tuhoaa vihun ja kutsuu rajahdyksen
    void kuole()
    {
        //TODO: implementoi kuolema ja rajahdys
    }

    // uusi kohde ja mahdollisesti beissin hajotus tai elamien vahennus
    /*void paasiKohteeseen(VihuWaypoint kohde)
    {
        if (kohde.onkoViimeinen)
        {
            kuole();
            //TODO vähennä elämiä pelaajalta
        }
        else
        {
            nykyinenKohde = kohde.seuraavaKohde;

        }
    }*/

    //is called a fixed number of times per second
    void FixedUpdate ()
    {
        //TODO liikuta vihua kohti waypointtia. A* vois toimia, mutta pitää tehdä kenttä sille
    }
}
