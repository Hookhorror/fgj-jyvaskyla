using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihuWaypoint : MonoBehaviour
{
    //viimeinen pitäisi pistää maaliin tai siis beissiin. muut ei ole viimeisiä
    public bool onkoViimeinen = true;
    //linkitety lista, osoittaa seuraavaan kohteeseen. null jos viimeinen
    public GameObject Waypoints;
    public GameObject seuraavaKohde;
    public int monesko = 0;

    void Awake()
    {
        string nimi = "Vihu_Waypoint_" + (monesko + 1).ToString("D2");
        seuraavaKohde = GameObject.Find(nimi); ;
        

    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    public GameObject haeSeuraavaKohde()
    {
        return seuraavaKohde;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
