﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowTo2 : MonoBehaviour
{
    public void NextInstruction()
    {
        SceneManager.LoadScene(sceneName: "HowTo3");
    }

    public void SkipInstructions()
    {
        SceneManager.LoadScene(sceneName: "LevelScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            NextInstruction();
        }
    }
}
