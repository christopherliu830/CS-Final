using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;
    public float acceleration;
    public bool racing;


    // Use this for initialization
    private void Awake()
    {
        this.enabled = false;
    }

    void OnEnable()
    {
        Debug.Log("CameraController enabled");
        racing = true;
    }

    void OnDisable()
    {
        racing = false;
    }

    private void FixedUpdate()
    {
        if (racing)
        {
            transform.position = new Vector3(Time.deltaTime * speed + transform.position.x, transform.position.y, transform.position.z);
            speed += acceleration;
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

}

