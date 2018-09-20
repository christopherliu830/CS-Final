using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

    private float maxSpeed;
    private float minSpeed; 
    private float speed;

	// Use this for initialization
	void Start () {

        maxSpeed = Camera.main.GetComponent<CameraController>().GetSpeed() + .2f;
        minSpeed = Camera.main.GetComponent<CameraController>().GetSpeed() + .1f;
        speed = Random.value * (maxSpeed-minSpeed) + minSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
	}
}
