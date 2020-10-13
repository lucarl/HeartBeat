using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PutOnPulseBandScript : MonoBehaviour
{
    public GameObject p1NameText;
    public GameObject p2NameText;

    public void ClickedDoneButton()
    {
        SceneManager.LoadScene(sceneName: "LevelScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        p1NameText.GetComponent<Text>().text = GameState.P1Name;
        p2NameText.GetComponent<Text>().text = GameState.P2Name;
        Debug.Log("Names have been set in PutOnPulseBandScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
