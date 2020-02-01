using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihuSpawner : MonoBehaviour
{
    // Aallot määrittää kuinka monessa kasassa vihut tulee
    [Header("Spawnaamisien muuttujat")]
    public int aaltoja = 5;
    [Tooltip("aika lasketaan frameissa eli 60 sekunnissa")]
    public int valiaikaVihut = 10; // kuinka monen framin valein vihut tulevat
    [Tooltip("aika lasketaan frameissa eli 60 sekunnissa")]
    public int valiaikaAallot = 100; // kuinka monen framin valein aallot tulee

    public VihuWaypoint nykyinenKohde;


    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //is called a fixed number of times per second
    void FixedUpdate()
    {
        //TODO laske milloin pitää spawnaa vihuja ja milloin odotetaan aaltoja
    }
}
