using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuUI_B : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Text text;
    public GameObject switchUI;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(text, 10f);
        Invoke("appear10Sec", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void appear10Sec()
    {
        switchUI.SetActive(true);
        Destroy(switchUI, 10f);
    }
}
