using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniManager : MonoBehaviour
{
    public GameManager gameManager;

    public Text finishText;
    public Text rankingText;
    public Text countdown;
    private float timeLeft = 3;

    // Use this for initialization
    IEnumerator Start()
    {
        yield return StartCoroutine(StartCountdown());
        StartMinigame();
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator StartCountdown()
    {
        while (timeLeft > 0)
        {
            countdown.text = ((int)(timeLeft -= Time.deltaTime) + 1).ToString();
            yield return null;
        }
        countdown.enabled = false;
    }

    void StartMinigame()
    {
        gameManager.enabled = true;
    }

    public void StopMinigame()
    {
        finishText.enabled = true;
        rankingText.enabled = true;
        Invoke("EndMinigame", 5);
    }

    public void AddPointsToTotal(int slot, int score) 
    {
        Debug.Log("Player " + (slot+1) + " gets " + score + " points.");
        PlayerData.playerPoints[slot] += score;
    }


    private void EndMinigame()
    {
        StopAllCoroutines();
        StartCoroutine(LoadNextSceneAsync());
    }

    IEnumerator LoadNextSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("betweenRounds");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
