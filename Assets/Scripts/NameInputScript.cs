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
        public static string p1Name;
        public static string p2Name;

        public GameObject p1InputField;
        public GameObject p2InputField;

        public void SaveNames()
        {
            p1Name = p1InputField.GetComponent<Text>().text;
            p2Name = p2InputField.GetComponent<Text>().text;

            if (String.IsNullOrEmpty(p1Name) || String.IsNullOrEmpty(p2Name))
            {
                Debug.Log("At least one name is empty... " + "P1 name: " + p1Name + " P2 name: " + p2Name);
                return;
            }

            Debug.Log("P1 name: " + p1Name + " P2 name: " + p2Name);

            SceneManager.LoadScene(sceneName: "PutOnPulseBandScene");
        }
    }
}
