using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

    public float speed = 5f;
    private Rigidbody body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        var val = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(speed * val, body.velocity.y);
	}
}
