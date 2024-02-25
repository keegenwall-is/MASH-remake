using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject creditsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        creditsCanvas = GameObject.Find("Credits Canvas");

        creditsCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            creditsCanvas.gameObject.SetActive(!creditsCanvas.gameObject.activeSelf);
        }
    }

    public void EnableCanvasOnClick()
    {
        
        creditsCanvas.gameObject.SetActive(!creditsCanvas.gameObject.activeSelf);
    }
}
