using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public float offsetX;
    public GameObject platform;
    public GameObject[] clouds;
    public GameObject coin;
    public float cloudSpawnChance;
    public float coinSpawnChance;
    public float coinCd;
    private float currentCoinCd;
    public float platformMaxCd;
    public float platformMinCd;
    private float currentPlatformCd;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //rb.velocity = new Vector3(1.5f, 0, 0);

        if (currentPlatformCd <= 0)
        {
            currentPlatformCd = Random.value*(platformMaxCd - platformMinCd) + platformMinCd;
            SpawnPlatform();
        }

        currentPlatformCd -= 1 * Time.deltaTime; 

        if (Random.value < cloudSpawnChance)
        {
            SpawnCloud();
        }
		
        if (currentCoinCd <= 0 && Random.value < coinSpawnChance)
        {
            currentCoinCd = coinCd;
            SpawnCoin();
        }

        currentCoinCd -= 1 * Time.deltaTime;

        
	}

    void SpawnPlatform()
    {
        float yCoord = transform.position.y - 6;
        Vector3 spawnPos = new Vector3(transform.position.x + platform.transform.position.x, yCoord, 0.0f);
        Instantiate(platform, spawnPos, Quaternion.identity);
    }

    void SpawnCloud()
    {
        float yCoord = Random.value * 4 ;
        Vector3 spawnPos = new Vector3(transform.position.x-20, yCoord, 0.0f);
        int i = (int)(Random.value * clouds.Length);
        Instantiate(clouds[i], spawnPos, Quaternion.identity);
    }

    void SpawnCoin()
    {
        float yCoord = Random.value * 4 - 2;
        Vector3 spawnPos = new Vector3(transform.position.x-20, yCoord, 0.0f);
        Instantiate(coin, spawnPos, Quaternion.identity);
    }
}
