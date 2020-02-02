using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rajahdys : MonoBehaviour
{
    public int elinIka = 2;
    private int ikaaJaljella;

    void Awake()
    {
        ikaaJaljella = elinIka;
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
        if (ikaaJaljella <= 0)
        {
            Destroy(this);
        }
        ikaaJaljella--;
    }
}
