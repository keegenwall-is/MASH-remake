using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLightning : MonoBehaviour
{

    public Animator anim;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("LightningStrikeAnim");
        StartCoroutine(DestroyAfterAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayElectricSFX()
    {
        audio.Play();
    }

    IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        Destroy(gameObject);
    }
}
