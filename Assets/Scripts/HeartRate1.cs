using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRate1 : MonoBehaviour {

    Text heartRateText;

    // Start is called before the first frame update
    void Start () {
        heartRateText = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update () {
        heartRateText.text = "HR: " + HeartRateScript.bpm1;
    }
}