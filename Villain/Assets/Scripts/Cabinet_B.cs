using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet_B : MonoBehaviour
{
    [SerializeField]
    GameObject[] objList;
    //public GameObject obj1;
    //public GameObject obj2;
    //public GameObject obj3;
    //public GameObject obj4;
    //public GameObject obj5;
    //public GameObject obj6;
    //public GameObject obj7;
    //public GameObject obj8;
    //public GameObject obj9;
    //public GameObject obj10;

    // Start is called before the first frame update
    void Start()
    {
        objList = GetComponentsInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Hand"))
        {
            return;
        }
    }
}
