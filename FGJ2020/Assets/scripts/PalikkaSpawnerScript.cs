using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalikkaSpawnerScript : MonoBehaviour
{
    public int valiaPalikoilla = 600;
    private int seuraavaanPalikkaan;
    public GameObject spawnattava;
    private Vector2 paikka;
    private GameObject spawnattu;
    public int valiAikaKunOtettiinEdellinen = 10;
    // Start is called before the first frame update
    void Start()
    {
        seuraavaanPalikkaan = 50;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawnaa()
    {
        spawnattu = (GameObject)Instantiate(spawnattava, gameObject.transform.position, new Quaternion());
        spawnattu.GetComponent<PartController>().SpawnattiinSpawnerista();
        seuraavaanPalikkaan = valiaPalikoilla;

    }

    //is called a fixed number of times per second
    void FixedUpdate()
    {
        if (seuraavaanPalikkaan <= 0 )
        {
            if (spawnattu == null)
            {
                Spawnaa();
            }
            else if (!spawnattu.GetComponent<PartController>().OnkoJalustallaGet())
            {
                spawnattu = null;
                seuraavaanPalikkaan = valiAikaKunOtettiinEdellinen;
            }
            //spawnaa palikka
        }
        else if (seuraavaanPalikkaan >= 0)
        {
            
            seuraavaanPalikkaan--;
        }

    }
}
