using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSceneScript : MonoBehaviour
{
    //The speed of the player
    private float playerSpeed = 1.2f;

    private static float _xPos = 0;

    public Rigidbody2D p1Sprite;
    private Rigidbody2D _p1Sprite;
    public Rigidbody2D p2Sprite;
    private Rigidbody2D _p2Sprite;

    public Text p1HeartRateText;
    private Text _p1HeartRateText;
    public Text p2HeartRateText;
    private Text _p2HeartRateText;

    public Text p1ScoreText;
    private Text _p1ScoreText;
    public Text p2ScoreText;
    private Text _p2ScoreText;

    public Text p1Name;
    public Text p2Name;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START LEVEL SCENE RUNNING!");
        _xPos = 0;

        _p1Sprite = p1Sprite.GetComponent<Rigidbody2D>();
        _p2Sprite = p2Sprite.GetComponent<Rigidbody2D>();

        _p1HeartRateText = p1HeartRateText.GetComponent<Text>();
        _p2HeartRateText = p2HeartRateText.GetComponent<Text>();

        _p1ScoreText = p1ScoreText.GetComponent<Text>();
        _p2ScoreText = p2ScoreText.GetComponent<Text>();

        p1Name.GetComponent<Text>().text = GameState.P1Name;
        p2Name.GetComponent<Text>().text = GameState.P2Name;
    }

    // Update is called once per frame
    void Update()
    {
        _xPos += playerSpeed * Time.deltaTime;
        _p1Sprite.transform.position = new Vector2(_xPos, GameState.P1HeartRate);
        _p2Sprite.transform.position = new Vector2(_xPos, GameState.P2HeartRate);

        _p1HeartRateText.text = GameState.P1HeartRate.ToString();
        _p2HeartRateText.text = GameState.P2HeartRate.ToString();

        _p1ScoreText.text = GameState.P1Score.ToString();
        _p2ScoreText.text = GameState.P2Score.ToString();

        if (_xPos > 10 /*225*/)
        {
            SceneManager.LoadScene("WinnerScene");
        }
    }
}
