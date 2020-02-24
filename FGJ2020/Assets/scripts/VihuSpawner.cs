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
    public int aallossaVihuja = 10;
    public int alkuPaussi = 260;

    public GameObject nykyinenKohde;

    public GameObject spawnattava;

    private Vector2 paikka;
    private int seuraavaanSpawniin = 0;
    private int aallonLoppuun;
    private int seuraavaanAaltoon;
    public GameObject[] listaKohteita;


    void Awake()
    {
        aallonLoppuun = aallossaVihuja;
        seuraavaanAaltoon = valiaikaAallot;
        seuraavaanSpawniin = alkuPaussi;
        
    }

    void spawnaa()
    {
        paikka = GameObject.Find("Vihu_Spawner").transform.position;
        Instantiate(spawnattava, paikka, new Quaternion());

    }

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
        if (seuraavaanSpawniin > 0)
        {
            seuraavaanSpawniin--;
        }
        else
        {
            spawnaa();
            seuraavaanSpawniin = valiaikaVihut;
            if (aallonLoppuun > 0 )
            {
                aallonLoppuun--;
            }
            else
            {
                Debug.Log("aalto loppui");
                seuraavaanSpawniin = valiaikaAallot;
                seuraavaanAaltoon = valiaikaAallot;
                aallonLoppuun = aallossaVihuja;
            }
        }

        //TODO laske milloin pitää spawnaa vihuja ja milloin odotetaan aaltoja


    }
}
