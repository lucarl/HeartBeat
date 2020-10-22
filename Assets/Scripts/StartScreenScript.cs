using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR_OSX || UNITY_IOS || UNITY_STANDALONE_OSX
public class StartScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayButtonClicked()
    {
        startGame();
    }

    private bool startedGame = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            startGame();
        }
    }

    private void startGame()
    {
        if (startedGame)
        {
            return;
        }

        startedGame = true;
        BluetoothScript.ConnectToPolar();
        SceneManager.LoadScene(sceneName: "PlayerNameScene");
        Debug.Log("Start Game!");
    }
}
#endif