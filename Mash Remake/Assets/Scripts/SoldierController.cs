using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public GameObject heli;

    public SoldiersCarried solCarriedScript;

    // Start is called before the first frame update
    void Start()
    {
        heli = GameObject.Find("Helicopter");
        solCarriedScript = heli.GetComponent<SoldiersCarried>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!solCarriedScript.maxCapacity)
        {
            Destroy(gameObject);
            //Debug.Log("hit");
        }
    }
}
