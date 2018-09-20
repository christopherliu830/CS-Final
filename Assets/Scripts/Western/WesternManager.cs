using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WesternManager : GameManager {

    public Text drawText;
    public Text[] timeTexts;
    public Text rankingText;
    private float currentTime = 0;
    private int currentPoints = 4;
    private List<Western_PlayerController> placings = new List<Western_PlayerController>();
    private bool drawn = false;
    private bool stopped = false;
    public int currentContestedPlace = 0;

    void OnEnable()
    {
        drawText.enabled = true;
        foreach (PlayerController pc in playerControllers) pc.enabled = true;
        Invoke("Draw", Random.Range(3, 9)); 
    }

    IEnumerator Stopwatch()
    {
        while (true)
        {
            currentTime += Time.deltaTime;
            for(int i = 0; i < timeTexts.Length; i++)
            {
                if (playerControllers[i].enabled == true) timeTexts[i].text = currentTime.ToString("N3");
            }
            yield return null;
        }
    }
    void Draw()
    {
        drawText.text = "DRAW!!!";
        StartCoroutine(Stopwatch());
        foreach(Text timeText in timeTexts) timeText.enabled = true;
        drawn = true;
    }

    public void RecordShot(Western_PlayerController pc)
    {
        if (!drawn)
        {
            Debug.Log(pc + " drew early");
            placings.Add(pc);
            pc.enabled = false;
            timeTexts[pc.GetSlot()].text = "EARLY";
            timeTexts[pc.GetSlot()].enabled = true;
            return;
        }
        if (drawText.enabled) drawText.enabled = false;
        pc.enabled = false;
        placings.Insert(currentContestedPlace, pc);
        miniManager.AddPointsToTotal(pc.slot, currentPoints);
        timeTexts[pc.slot].text = currentTime.ToString("N3");
        currentPoints--;
        currentContestedPlace++;
    }

    private void Update()
    {
        if (!stopped && placings.Count == playerControllers.Count)
        {
            Invoke("StopMinigame", 3);
            stopped = true;
        }
    }
    void StopMinigame()
    {
        Debug.Log("Stopping Western");
        StopCoroutine(Stopwatch());
        foreach (Text t in timeTexts) t.enabled = false;
        drawText.enabled = false;
        string rankingString = "";
        for (int i = 0; i < placings.Count; i++)
        {
            string color = placings[i].GetColor();
            int slot = placings[i].GetSlot();
            int points = PlayerData.playerPoints[slot] - PlayerData.playerPointsOld[slot];
            rankingString += ((i+1) + ": " + color + ", +" + points + "\n");
        }
        rankingText.text = rankingString;

        miniManager.StopMinigame();

    }

}
