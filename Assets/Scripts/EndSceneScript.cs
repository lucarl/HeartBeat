using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    public GameObject p1ScoreText;
    public GameObject p2ScoreText;

    public GameObject p1NameText;
    public GameObject p2NameText;

    // Start is called before the first frame update
    void Start()
    {
        p1ScoreText.GetComponent<Text>().text = "x " + GameState.P1Score;
        p2ScoreText.GetComponent<Text>().text = "x " + GameState.P2Score;

        p1NameText.GetComponent<Text>().text = GameState.P1Name;
        p2NameText.GetComponent<Text>().text = GameState.P2Name;
    }
}
