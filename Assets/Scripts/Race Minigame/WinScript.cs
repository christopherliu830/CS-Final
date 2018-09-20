using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{

    public RaceManager rm;
    public MiniManager miniManager;
    public LayerMask playerMask;
    private int currentPlace = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider) //someone won the game
    {
        if (collider.gameObject.tag == "Player")
        {
            rm.RecordPlacing(collider.gameObject.GetComponent<Race_PlayerController>(), true);
            miniManager.AddPointsToTotal(collider.gameObject.GetComponent<PlayerController>().slot, 1);
            currentPlace++;
        }
    }
}
