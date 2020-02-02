using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalikkaSpawnerScript : MonoBehaviour
{
    public int valiaPalikoilla = 600;
    private int seuraavaanPalikkaan;
    public GameObject spawnattava;
    private Vector2 paikka;
    // Start is called before the first frame update
    void Start()
    {
        seuraavaanPalikkaan = valiaPalikoilla;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //is called a fixed number of times per second
    void FixedUpdate()
    {
        if (seuraavaanPalikkaan <= 0)
        {
            //spawnaa palikka
            paikka = GameObject.Find("PalikkaSpawner").transform.position;
            Instantiate(spawnattava, paikka, new Quaternion());
            seuraavaanPalikkaan = valiaPalikoilla;
        }
        seuraavaanPalikkaan--;

    }
}
