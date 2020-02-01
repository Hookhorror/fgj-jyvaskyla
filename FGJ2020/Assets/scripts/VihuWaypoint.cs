using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihuWaypoint : MonoBehaviour
{
    //viimeinen pitäisi pistää maaliin tai siis beissiin. muut ei ole viimeisiä
    public bool onkoViimeinen = true;
    //linkitety lista, osoittaa seuraavaan kohteeseen. null jos viimeinen
    public VihuWaypoint seuraavaKohde;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
