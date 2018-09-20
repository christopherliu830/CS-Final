using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {


    public static int[] playerPointsOld { get; set; }
    public static int[] playerPoints { get; set; }

    public static KeyCode[] playerKeys { get; set; }

    void Awake()
    {
        if (playerPoints == null) playerPoints = new int[] { 0, 0, 0, 0 };
        if (playerPointsOld == null) playerPointsOld = new int[] { 0, 0, 0, 0 };
        if (playerKeys == null) playerKeys = new KeyCode[] {KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R};

        foreach(int player in playerPoints)
        {
            Debug.Log(player);
        }
    }
}
