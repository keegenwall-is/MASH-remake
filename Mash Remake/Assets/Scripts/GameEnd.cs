using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    GameObject[] assets;

    bool solFound = false;

    public Text restartTxt;

    public Text youWinTxt;

    // Start is called before the first frame update
    void Start()
    {
        restartTxt = GameObject.Find("Restart").GetComponent<Text>();
        youWinTxt = GameObject.Find("You Win").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        assets = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject asset in assets)
        {
            if (asset.CompareTag("Soldier"))
            {
                solFound = true;
                break;
            }
        }

        if (!solFound)
        {
            youWinTxt.text = "YOU WIN";
            restartTxt.text = "PRESS R TO RESTART";
        }
    }   
}
