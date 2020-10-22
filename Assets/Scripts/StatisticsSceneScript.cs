using System.Collections;
using System.Collections.Generic;
using UnityCoreBluetoothFramework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR_OSX || UNITY_IOS || UNITY_STANDALONE_OSX
public class StatisticsSceneScript : MonoBehaviour
{

    public Image p1GoldMedal;
    public Image p2GoldMedal;
    public Image p1SilverMedal;
    public Image p2SilverMedal;

    public Text p1ScoreText;
    public Text p2ScoreText;

    public Text p1NameText;
    public Text p2NameText;

    public Text p1LowestHRText;
    public Text p2LowestHRText;

    public Text p1HighestHRText;
    public Text p2HighestHRText;

    public void PlayAgain()
    {
        GameState.ResetGame();
        UnityCoreBluetooth.ReleaseSharedInstance();
        SceneManager.LoadScene(sceneName: "StartScene");
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

    // Start is called before the first frame update
    void Start()
    {
        p1ScoreText.GetComponent<Text>().text = GameState.P1Score.ToString();
        p2ScoreText.GetComponent<Text>().text = GameState.P2Score.ToString();

        p1NameText.GetComponent<Text>().text = GameState.P1Name;
        p2NameText.GetComponent<Text>().text = GameState.P2Name;

        p1LowestHRText.GetComponent<Text>().text = GameState.P1LowestHR.ToString();
        p2LowestHRText.GetComponent<Text>().text = GameState.P2LowestHR.ToString();

        p1HighestHRText.GetComponent<Text>().text = GameState.P1HighestHR.ToString();
        p2HighestHRText.GetComponent<Text>().text = GameState.P2HighestHR.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHiddenMedals)
        {
            HideMedals();
        }
    }
}
#endif