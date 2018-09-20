using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    private Rigidbody2D rb;
    private CameraController camc;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        camc = Camera.main.GetComponent<CameraController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

        rb.velocity = new Vector3(camc.GetSpeed()+1, 0, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Race_PlayerController pc = collision.GetComponent<Race_PlayerController>();
            pc.Boost(camc.GetSpeed()+1, 3);
            Destroy(gameObject);
        }
    }
}
