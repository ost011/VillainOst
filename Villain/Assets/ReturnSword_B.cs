using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnSword_B : MonoBehaviour
{
    [SerializeField]
    GameObject swdcab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Under"))
        {
            Debug.Log("Sword has fallen!");
        }
    }
}
