using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerController : MonoBehaviour
{
    public RaceManager rm;
    public static int lastPlace = 3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null && collision.gameObject.tag.Equals("Player"))
        {
            rm.RecordPlacing(collision.gameObject.GetComponent<Race_PlayerController>(), false);
        }
        else Destroy(collision.gameObject);
    }

}
