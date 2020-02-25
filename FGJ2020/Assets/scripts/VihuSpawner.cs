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
    public int seuraavassaAallossaEnemman = 1;
    public int alkuPaussi = 260;
    public float maxPyoriminen = 50f;

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
        
        paikka = gameObject.transform.position;
        GameObject spawnattu =(GameObject)Instantiate(spawnattava, paikka, new Quaternion());
        if (Random.value > 0.5f)
        {

            spawnattu.GetComponent<Rigidbody2D>().AddTorque(Random.Range((maxPyoriminen*-0.5f), maxPyoriminen * -1f));
        }
        else
        {
            spawnattu.GetComponent<Rigidbody2D>().AddTorque(Random.Range((maxPyoriminen * 0.5f), maxPyoriminen));

        }

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
                aallossaVihuja += seuraavassaAallossaEnemman;
            }
        }

        //TODO laske milloin pitää spawnaa vihuja ja milloin odotetaan aaltoja


    }
}
