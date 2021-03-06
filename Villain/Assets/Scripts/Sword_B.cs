using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_B : MonoBehaviour
{
    public float attackAmount = 25f;
    public AudioClip swordHit;
    public AudioClip swordSwing;
    AudioSource swordAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        swordAudio = GetComponent<AudioSource>();
        swordAudio.volume = 10.0f;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            MonsterCtrl_C mst = other.GetComponent<MonsterCtrl_C>();
            if(mst != null)
            {
                mst.GetDamage(attackAmount);
            }
            swordAudio.PlayOneShot(swordHit);
        }
        //else if (other.tag)
        //{
        //    if()
        //}
    }
    public void swordgrabbed()
    {
        Debug.Log("sword grabbed");
        if (GameObject.Find("SwordTrail_B").GetComponent<TrailRenderer>().enabled == false)
        {
            GameObject.Find("SwordTrail_B").GetComponent<TrailRenderer>().enabled = true;
        }
    }
    public void dropsword()
    {
        Debug.Log("sword dropped");
        if (GameObject.Find("SwordTrail_B").GetComponent<TrailRenderer>().enabled == true)
        {
            GameObject.Find("SwordTrail_B").GetComponent<TrailRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //float x = GetComponent<Rigidbody>().velocity.x;
        //float y = GetComponent<Rigidbody>().velocity.y;
        //float z = GetComponent<Rigidbody>().velocity.z;
        //if (Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z) > 0.3f)
        //{
        //    swordAudio.PlayOneShot(swordSwing);
        //    Debug.Log("swing!");
        //}
        
    }
}
