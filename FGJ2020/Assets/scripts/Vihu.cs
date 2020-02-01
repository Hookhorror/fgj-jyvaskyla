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
    private float moveSpeed = 2f;
    [Tooltip("1.0 on normaali")]
    public float speedScaleWhenSlowed = 0.5f;
    [Header("Näille tekee erilaisia vihuja")]
    public bool isImmuneToSlow = false;

    private Rigidbody2D rb;
    private bool isSlowed = false;

    [Header("Kohde minne vihu on menossa")]
    [Tooltip("Pitäisi olla ensimmäinen waypoint")]

    public GameObject nykyinenKohde;
    private int kohdeLaskuri = 0;
    public int viimeinenKohde = 2;


    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        nykyinenKohde = GameObject.Find("Vihu_Waypoint_00");

        //GameObject.Find("Vihu_Waypoint").transform.position;
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
        speedScale = 0f;
        //TODO: implementoi kuolema ja rajahdys
    }

    // uusi kohde ja mahdollisesti beissin hajotus tai elamien vahennus
    void paasiKohteeseen(GameObject kohde)
    {
        kohdeLaskuri++;
        Debug.Log("paasikohteeseen" + kohdeLaskuri);
        //kohde.onkoViimeinen //TODO korvaa
        if (kohdeLaskuri >= viimeinenKohde)
        {
            kuole();
            //TODO vähennä elämiä pelaajalta
        }
        else
        {
            GameObject vanhaKohde = nykyinenKohde;
            nykyinenKohde = vanhaKohde.haeSeuraavaKohde();
            //nykyinenKohde = kohde.seuraavaKohde;
            //nykyinenKohde = GameObject.Find("Vihu_Waypoint_" + kohdeLaskuri.ToString("D2") );
            
            

        }
    }

    //is called a fixed number of times per second
    void FixedUpdate ()
    {
        //minne pitää mennä
        Vector2 suunta = nykyinenKohde.transform.position;
        suunta = suunta - rb.position;
        Debug.Log("" + suunta.magnitude);
        if (suunta.magnitude <= 0.5f)
        {
            paasiKohteeseen(nykyinenKohde);
        }

        // hidastetaan jos pitää ja vihua voi hidastaa
        float kerroin = 1.0f;
        if (!isImmuneToSlow & isSlowed)
        {
            kerroin = speedScaleWhenSlowed;
        }

        rb.MovePosition(rb.position + suunta.normalized * kerroin * moveSpeed * Time.fixedDeltaTime);
        //TODO liikuta vihua kohti waypointtia. A* vois toimia, mutta pitää tehdä kenttä sille
    }
}
