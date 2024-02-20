using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersCarried : MonoBehaviour
{

    public int noOfSol;

    // Start is called before the first frame update
    void Start()
    {
        noOfSol = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Soldier")
        {
            noOfSol += 1;
            Debug.Log(noOfSol);
        }

        if (collision.gameObject.tag == "Hospital")
        {
            noOfSol = 0;
            Debug.Log("Heli empty");
        }
    }
}
