using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerNames;

public class PutOnPulseBandScript : MonoBehaviour
{
    public GameObject p1NameText;
    public GameObject p2NameText;

    // Start is called before the first frame update
    void Start()
    {
        p1NameText.GetComponent<Text>().text = NameInputScript.p1Name;
        p2NameText.GetComponent<Text>().text = NameInputScript.p2Name;
        Debug.Log("Names have been set in PutOnPulseBandScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
