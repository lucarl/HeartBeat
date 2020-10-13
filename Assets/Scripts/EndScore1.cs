using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore1 : MonoBehaviour {

    Text scoreText;

    // Start is called before the first frame update
    void Start () {
        scoreText = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update () {
        scoreText.text = "x " + Player1.points;
    }
}