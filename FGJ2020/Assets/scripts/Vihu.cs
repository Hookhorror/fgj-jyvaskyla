using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vihu : MonoBehaviour
{
    public int hp = 100;
    public double speedScale = 1.0;
    public double speedScaleWhenSlowed = 0.5;
    public bool isSlowed = false;
    public bool isImmuneToSlow = false;
    //public VihuWaypoint nykyinenKohde;

    void Awake()
    {

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
