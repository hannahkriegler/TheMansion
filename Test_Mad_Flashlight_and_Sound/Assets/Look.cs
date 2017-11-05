using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour {
   
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Light flashlight;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            flashlight.enabled = !flashlight.enabled;
        }

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        Vector3 v = new Vector3(pitch, yaw, 0.0f);
        transform.eulerAngles = v;


        
	}
}
