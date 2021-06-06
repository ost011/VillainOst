using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckhasThrown_B : MonoBehaviour
{
    private XRDirectInteractor xdi;
    //private Grenade_B gren;

    public AudioClip swing;
    AudioSource swingSource;
    private bool hasThrown = false;
    // Start is called before the first frame update
    void Start()
    {
        swingSource = GetComponent<AudioSource>();
        xdi = GetComponent<XRDirectInteractor>();
        //gren = GetComponent<Grenade_B>();
    }

    // Update is called once per frame
    void Update()
    {
        //var gre = GameObject.FindWithTag("Grenade").GetComponent<Grenade_B>();
        //if (GameObject.FindWithTag("Grenade_B") != null)
        //{
        //    var gre = GameObject.FindWithTag("Grenade_B").GetComponent<Grenade_B>();
        //    if (gre.hasThrown == true)
        //    {
        //        Debug.Log("bomb");
        //        swingSource.PlayOneShot(swing);
        //    }
        //}

    }
    public IEnumerator waitfor2Sec()
    {
        yield return new WaitForSeconds(2f);
        
        var gre = GameObject.FindWithTag("Grenade").GetComponent<Grenade_B>();
        if (gre.hasThrown == true)
        {
            swingSource.PlayOneShot(swing);
        }
        else
            StopAllCoroutines();
    }
}
