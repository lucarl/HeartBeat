using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRateScript : MonoBehaviour
{

    Text heartRate;

    // Start is called before the first frame update
    void Start()
    {
        heartRate = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        heartRate.text = "HR: " + Player.heartRate;
    }
}
