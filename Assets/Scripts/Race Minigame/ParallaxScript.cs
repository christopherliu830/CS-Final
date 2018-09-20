using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour {

    public Transform[] backgrounds;
    public float[] parallaxScales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start () {

        previousCamPos = cam.position;
		
	}

    void Update() {

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (cam.position.x - previousCamPos.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

            if (backgrounds[i].position.x < cam.position.x - 32) backgrounds[i].position = new Vector3(cam.position.x + 32, backgrounds[i].position.y, backgrounds[i].position.z);
            if (backgrounds[i].position.x > cam.position.x + 32) backgrounds[i].position = new Vector3(cam.position.x - 32, backgrounds[i].position.y, backgrounds[i].position.z);

        }

        previousCamPos = cam.position;
		
	}
}
