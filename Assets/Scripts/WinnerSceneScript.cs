using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerSceneScript : MonoBehaviour
{
    public Image p1GoldMedal;
    public Image p2GoldMedal;
    public Image p1SilverMedal;
    public Image p2SilverMedal;

    public GameObject p1ScoreText;
    public GameObject p2ScoreText;

    public GameObject p1NameText;
    public GameObject p2NameText;

    // Start is called before the first frame update
    void Start()
    {
        p1ScoreText.GetComponent<Text>().text = GameState.P1Score.ToString();
        p2ScoreText.GetComponent<Text>().text = GameState.P2Score.ToString();

        p1NameText.GetComponent<Text>().text = GameState.P1Name;
        p2NameText.GetComponent<Text>().text = GameState.P2Name;
    }

    private void HideMedals()
    {
        if (GameState.P1Score == GameState.P2Score)
        {
            p1SilverMedal.GetComponent<Image>().enabled = false;
            p2SilverMedal.GetComponent<Image>().enabled = false;
        }
        else if (GameState.P1Score > GameState.P2Score)
        {
            p1SilverMedal.GetComponent<Image>().enabled = false;
            p2GoldMedal.GetComponent<Image>().enabled = false;
        }
        else
        {
            p1GoldMedal.GetComponent<Image>().enabled = false;
            p2SilverMedal.GetComponent<Image>().enabled = false;
        }

        hasHiddenMedals = true;
    }

    private bool hasHiddenMedals = false;
    private float timer = 0.0f;

    private void Update()
    {
        if (!hasHiddenMedals)
        {
            HideMedals();
        }

        timer += Time.deltaTime;
        int seconds = Convert.ToInt32( timer % 60);

        if (seconds > 10 || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(sceneName: "StatisticsScene");
        }
    }
}
