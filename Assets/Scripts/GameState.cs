using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static string P1Name = "Player 1";
    public static string P2Name = "Player 2";

    public static bool P1Connected = false;
    public static bool P2Connected = false;

    public static int P1HeartRate = 40;
    public static int P2HeartRate = 40;

    public static int P1Score = 0;
    public static int P2Score = 0;
}
