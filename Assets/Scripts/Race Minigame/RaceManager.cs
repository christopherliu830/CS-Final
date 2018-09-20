using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceManager : GameManager
{

    public Text rankingText;
    private SpawnerController spawner;
    public CameraController camc;

    private List<Race_PlayerController> placings = new List<Race_PlayerController>();

    private int currentContestedPlace = 0;
    private int currentLastPlace = 3;

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        spawner = Camera.main.GetComponentInChildren<SpawnerController>();
        camc = Camera.main.GetComponent<CameraController>();
    }

    void OnEnable()
    {
        for (int i = 0; i < playerControllers.Count; i++)
        {
            Debug.Log("trying to enable: " + playerControllers[i]);
            playerControllers[i].enabled = true;
        }
        camc.enabled = true;
        spawner.gameObject.SetActive(true);
        DestroyerController.lastPlace = 3;
    }

    private void Update()
    {
        bool racing = false;
        {
            foreach(PlayerController pc in playerControllers) if (pc.enabled) racing = true;
        }
        if (!racing) StopRacing();
    }

    void StopRacing()
    {
        camc.enabled = false;
        spawner.gameObject.SetActive(false);

        string rankingString = "";
        for (int i = 0; i < placings.Count; i++)
        {
            string color = placings[i].GetColor();
            int slot = placings[i].GetSlot();
            int points = PlayerData.playerPoints[slot] - PlayerData.playerPointsOld[slot];
            rankingString += (i + 1 + ": " + color + ", +" + points + "\n");
        }
        rankingText.text = rankingString;

        miniManager.StopMinigame();
    }

    public void RecordPlacing(Race_PlayerController player, bool won)
    {
        player.enabled = false;
        if (won)
        {
            placings.Insert(currentContestedPlace, player);
            miniManager.AddPointsToTotal(player.slot, 4 - currentContestedPlace);
            currentContestedPlace++;
        }
        else
        {
            placings.Insert(currentContestedPlace, player);
            miniManager.AddPointsToTotal(player.slot, 4 - currentLastPlace);
            currentLastPlace--;
        }
    }
}
