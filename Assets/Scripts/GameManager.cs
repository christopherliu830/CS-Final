using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<PlayerController> playerControllers;
    public MiniManager miniManager;
    protected virtual void Awake()
    {
        this.enabled = false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
