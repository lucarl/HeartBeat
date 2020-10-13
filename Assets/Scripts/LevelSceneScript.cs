using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSceneScript : MonoBehaviour
{
    //The speed of the player
    private float playerSpeed = 1.5f;

    private static float _xPos = 0;

    public GameObject p1Sprite;
    public GameObject p2Sprite;

    public GameObject p1HeartRateText;
    public GameObject p2HeartRateText;

    public GameObject p1ScoreText;
    public GameObject p2ScoreText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _xPos += playerSpeed * Time.deltaTime;
        p1Sprite.GetComponent<Rigidbody2D>().transform.position = new Vector2(_xPos, GameState.P1HeartRate);
        p2Sprite.GetComponent<Rigidbody2D>().transform.position = new Vector2(_xPos, GameState.P2HeartRate);

        p1HeartRateText.GetComponent<Text>().text = "HR: " + GameState.P1HeartRate;
        p2HeartRateText.GetComponent<Text>().text = "HR: " + GameState.P2HeartRate;

        p1ScoreText.GetComponent<Text>().text = GameState.P1Name + ": " + GameState.P1Score;
        p2ScoreText.GetComponent<Text>().text = GameState.P2Name + ": " + GameState.P2Score;

        if (_xPos > 263) {
            SceneManager.LoadScene("EndScene");
        }
    }
}
