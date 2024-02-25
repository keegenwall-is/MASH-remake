using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeCollisions : MonoBehaviour
{
    private GameObject heli;
    private HelicopterMovement heliMoveScript;

    public Text gameOverTxt;

    public Text restartTxt;

    //public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        heli = GameObject.Find("Helicopter");
        heliMoveScript = heli.GetComponent<HelicopterMovement>();

        //canvas = GameObject.Find("Canvas");
        gameOverTxt = GameObject.Find("Game Over").GetComponent<Text>();
        restartTxt = GameObject.Find("Restart").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        heliMoveScript.moveSpeed = 0;

        gameOverTxt.text = "GAME OVER";
        restartTxt.text = "PRESS R TO RESTART";
    }
}
