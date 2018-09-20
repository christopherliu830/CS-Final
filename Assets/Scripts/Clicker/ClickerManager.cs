using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : GameManager {

    public int countdown;
    public Text countdownText;
    public Text rankingText;


	// Use this for initialization
	void OnEnable() {
        foreach(Clicker_PlayerController pc in playerControllers) pc.enabled = true;
        StartCoroutine(Countdown());
	}
	
	void Update () {
		
	}

    IEnumerator Countdown()
    {
        countdownText.enabled = true;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            countdown--;
            Debug.Log("TIME: " + countdown);
            yield return new WaitForSeconds(1);
        }
        countdownText.enabled = false;
        StopMinigame();
    }

    void StopMinigame()
    {
        Debug.Log("Stopping Clicker");
        List<Clicker_PlayerController> placings = new List<Clicker_PlayerController>();
        foreach (PlayerController pc in playerControllers) placings.Add((Clicker_PlayerController)pc);
        placings.Sort(delegate (Clicker_PlayerController a, Clicker_PlayerController b)
        {
            return b.GetPoints().CompareTo(a.GetPoints());
        });

        string rankingString = "";
        for (int i = 0; i < placings.Count; i++)
        {
            rankingString += (i + 1 + ": " + placings[i].GetColor() + ", +" + (4 - i) + "\n");
            miniManager.AddPointsToTotal(placings[i].GetSlot(), 4 - i);
        }
        rankingText.text = rankingString;

        miniManager.StopMinigame();
    }   
}
