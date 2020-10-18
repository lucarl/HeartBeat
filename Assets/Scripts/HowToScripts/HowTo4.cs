using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowTo4 : MonoBehaviour
{
    public Text p1NameText;
    public Text p2NameText;

    public Text countDown;
    private Text _countDown;

    public void GoToLevelScene()
    {
        SceneManager.LoadScene(sceneName: "LevelScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        p1NameText.GetComponent<Text>().text = GameState.P1Name;
        p2NameText.GetComponent<Text>().text = GameState.P2Name;

        _countDown = countDown.GetComponent<Text>();
    }

    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = Convert.ToInt32( timer % 60);

        if (seconds < 6)
        {
            _countDown.text = (5 - seconds).ToString();
        }

        if (seconds > 5)
        {
            GoToLevelScene();
        }
    }
}
