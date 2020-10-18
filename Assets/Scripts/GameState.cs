using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static string P1Name = "Player 1";
    public static string P2Name = "Player 2";

    public static bool P1Connected = false;
    public static bool P2Connected = false;

    public static int P1Score = 0;
    public static int P2Score = 0;

    public static int P1LowestHR = 200;
    public static int P2LowestHR = 200;
    public static int P1HighestHR = 10;
    public static int P2HighestHR = 10;

    private static int _p1HR = 10;
    private static int _p2HR = 10;

    public static int P1HeartRate
    {
        get => _p1HR;
        set
        {
            _p1HR = value;
            if (value > 40)
            {
                P1LowestHR = Math.Min(value, P1LowestHR);
            }
            P1HighestHR = Math.Max(value, P1HighestHR);
        }
    }

    public static int P2HeartRate
    {
        get => _p2HR;
        set
        {
            _p2HR = value;
            if (value > 40)
            {
                P2LowestHR = Math.Min(value, P2LowestHR);
            }
            P2HighestHR = Math.Max(value, P2HighestHR);
        }
    }


    public static void ResetGame()
    {
        P1Name = "Player 1";
        P2Name = "Player 2";

        P1Connected = false;
        P2Connected = false;

        P1Score = 0;
        P2Score = 0;

        _p1HR = 10;
        _p2HR = 10;

        P1LowestHR = 200;
        P2LowestHR = 200;
        P1HighestHR = 10;
        P2HighestHR = 10;
    }
}
