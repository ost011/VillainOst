using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_B : MonoBehaviour
{
    public float attackAmount = 50f;
    public AudioClip swordClip;
    AudioSource swordAudio;

    // Start is called before the first frame update
    void Start()
    {
        swordAudio = GetComponent<AudioSource>();
        swordAudio.volume = 2.0f;
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
            swordAudio.PlayOneShot(swordClip);
        }
        //else if (other.tag)
        //{
        //    if()
        //}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
