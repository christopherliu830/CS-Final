using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour {

    public Text[] scoreTexts;
    public Text nextRoundText;

    public string[] scenes;
    private int nextRoundIndex;

	// Use this for initialization
	IEnumerator Start () {
        UpdateText();
        yield return new WaitForSeconds(3.0f);
        yield return StartCoroutine(AnimateScores());
        yield return new WaitForSeconds(2.0f);
        nextRoundText.enabled = true;
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(NextRoundRoulette());
	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator AnimateScores()
    {
        bool changed = true;
        while (changed)
        {
            changed = false;
            int[] temp = PlayerData.playerPointsOld;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < PlayerData.playerPoints[i])
                {
                    temp[i]++;
                    changed = true;
                }
            }
            UpdateText();
            yield return new WaitForSeconds(.05f);
        }
    }

    IEnumerator NextRoundRoulette()
    {
        float waitTime = 0.01f;
        for(int i = 0; i < 30; i++)
        {
            nextRoundIndex = (int)Random.Range(0, scenes.Length);
            nextRoundText.text = scenes[nextRoundIndex];
            waitTime *= 1.10f;
            yield return new WaitForSeconds(waitTime);
        }
        Invoke("LoadNextRound", 3);

    }

    void UpdateText()
    {
        for (int i = 0; i < PlayerData.playerPointsOld.Length; i++)
        {
            scoreTexts[i].text = PlayerData.playerPointsOld[i].ToString();
        }
    }

    void LoadNextRound()
    {
        StopAllCoroutines();
        SceneManager.LoadScene(scenes[nextRoundIndex]);
    }
}
