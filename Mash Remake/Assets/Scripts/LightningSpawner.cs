using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningSpawner : MonoBehaviour
{

    public float lightningCD = 5.0f;

    float currentLightningCD = 0.0f;

    public GameObject Lightning;

    private bool noLightning = true;

    public Animator anim;

    private List<GameObject> soldiers = new List<GameObject>();

    public Text restartTxt;

    public Text youWinTxt;

    private GameObject heli;
    private HelicopterMovement heliMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        currentLightningCD = lightningCD;

        restartTxt = GameObject.Find("Restart").GetComponent<Text>();
        youWinTxt = GameObject.Find("You Win").GetComponent<Text>();

        heli = GameObject.Find("Helicopter");
        heliMoveScript = heli.GetComponent<HelicopterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (noLightning)
        {
            currentLightningCD -= 1 * Time.deltaTime;
            Debug.Log(currentLightningCD);

            if (currentLightningCD <= 0)
            {
                currentLightningCD = lightningCD;
                StartCoroutine(LightningCast());

            }
        }
    }

    IEnumerator LightningCast()
    {
        soldiers.Clear();

        GameObject[] soldierObjects = GameObject.FindGameObjectsWithTag("Soldier");
        foreach (GameObject soldier in soldierObjects)
        {
            soldiers.Add(soldier);
        }

        GameObject randSol = null;

        if (soldiers.Count > 0)
        {
            randSol = soldiers[Random.Range(0, soldiers.Count)];

            Vector3 soldierPos = randSol.transform.position;

            Vector3 lightningPos = new Vector3(soldierPos.x, soldierPos.y + 6, soldierPos.z);

            noLightning = false;
            Instantiate(Lightning, lightningPos, Quaternion.Euler(0, 0, 90));
        } else
        {
            Debug.LogWarning("No soldiers found in the scene.");
        }

        yield return new WaitForSeconds(15);

        if (randSol != null && randSol.activeSelf)
        {
            //game over
            youWinTxt.text = "GAME OVER";
            restartTxt.text = "PRESS R TO RESTART";
            heliMoveScript.moveSpeed = 0;
        }
        else
        {
            noLightning = true; ;
        }

        //Debug.Log("Animation Finished");
    }
}
