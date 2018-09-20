using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour {

    public Text[] kcodeTexts;

	// Use this for initialization
	void Start () {

        PlayerData.playerPoints = new int[4];
        PlayerData.playerPointsOld = new int[4];
        PlayerData.playerKeys = new KeyCode[4] { KeyCode.Space, KeyCode.Q, KeyCode.X, KeyCode.C };

        for (int i = 0; i < kcodeTexts.Length; i++)
        {
            kcodeTexts[i].text = PlayerData.playerKeys[i].ToString();
        }

        //Invoke("StartGame", 5);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("betweenRounds");
    }

    public void ChangeKeyCode(int slot)
    {
        Debug.Log("Listening for Key Press");
        StartCoroutine(getKeyPressed(slot));
    }

    IEnumerator getKeyPressed(int slot)
    {
        float timer= 5;
        KeyCode old = PlayerData.playerKeys[slot];
        while (timer > 0 && PlayerData.playerKeys[slot] == old)
        {

            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    Debug.Log(kcode + " pressed");
                    PlayerData.playerKeys[slot] = kcode;
                    kcodeTexts[slot].text = kcode.ToString();
                    Debug.Log(PlayerData.playerKeys[slot]);
                }
            }
            timer -= 1 * Time.deltaTime;
            yield return null;
        }
        Debug.Log("Time out");
    }
}
