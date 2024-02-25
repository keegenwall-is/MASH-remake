using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldiersCarried : MonoBehaviour
{

    public int noOfSol;

    public ScoreCounter scoreCounterScript;

    public GameObject canvas;

    public Text currentSol;

    public Animator anim;

    public AudioSource audioP;

    public AudioClip heliFullSFX;
    public AudioClip heliNotFullSFX;

    private bool isHeliFullSFXPlaying = false;

    public AudioSource solPickupSFX;

    public bool maxCapacity = false;

    // Start is called before the first frame update
    void Start()
    {
        noOfSol = 0;
        canvas = GameObject.Find("Canvas");
        scoreCounterScript = canvas.GetComponent<ScoreCounter>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (noOfSol == 3)
        {

            maxCapacity = true;

            if (!isHeliFullSFXPlaying)
            {
                anim.Play("HelicopterFullAnim");
                audioP.clip = heliFullSFX;
                audioP.loop = true;
                audioP.Play();
                isHeliFullSFXPlaying = true;
            }
        } else
        {

            maxCapacity = false;

            if (isHeliFullSFXPlaying)
            {
                anim.Play("HelicopterMoveAnim");
                audioP.clip = heliNotFullSFX;
                audioP.loop = true;
                audioP.Play();
                isHeliFullSFXPlaying = false;
            } 
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Soldier")
        {
            if (!maxCapacity)
            {
                noOfSol += 1;
                //Debug.Log(noOfSol);

                currentSol.text = "Soldiers in Helicopter: " + noOfSol;

                solPickupSFX.Play();
            }
            
        }

        if (collision.gameObject.tag == "Hospital")
        {
            // increase score
            scoreCounterScript.IncreaseCounter(noOfSol);

            // set noOfSol in heli back to 0
            noOfSol = 0;
            //Debug.Log("Heli empty");
            currentSol.text = "Soldiers in Helicopter: " + noOfSol;
        }
    }
}
