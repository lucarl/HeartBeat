using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace PlayerNames
{
    public class NameInputScript : MonoBehaviour
    {
        public GameObject p1InputField;
        public GameObject p2InputField;

        public void SaveNames()
        {
            string p1Name = p1InputField.GetComponent<Text>().text;
            string p2Name = p2InputField.GetComponent<Text>().text;

            if (String.IsNullOrEmpty(p1Name) || String.IsNullOrEmpty(p2Name))
            {
                Debug.Log("At least one name is empty... " + "P1 name: " + p1Name + " P2 name: " + p2Name);
                return;
            }

            GameState.P1Name = p1Name;
            GameState.P2Name = p2Name;

            Debug.Log("P1 name: " + p1Name + " P2 name: " + p2Name);

            SceneManager.LoadScene(sceneName: "PutOnPulseBandScene");
        }
    }
}
