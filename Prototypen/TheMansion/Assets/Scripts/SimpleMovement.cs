using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

    public float speed = 5f;
    public Buttons[] input;
    private Rigidbody body;
    private InputState inputState;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        inputState = GetComponent<InputState>();
	}

    // Update is called once per frame
    void Update() {
        var right = inputState.GetButtonValue(input[0]);
        var left = inputState.GetButtonValue(input[1]);
        var up = inputState.GetButtonValue(input[2]);
        var down = inputState.GetButtonValue(input[3]);

        Debug.Log("right is " + right);
        Debug.Log("left is " + left);
        Debug.Log("up is " + up);
        Debug.Log("down is " + down);

        var velX = speed;
        var velZ = speed;

        if ((right || left) && (up || down))
        {
            velZ *= down ? -1 : 1;
            velX *= left ? -1 : 1;
            Debug.Log("beide richtungen");
        }
        else if ((right || left) && !(up || down))
        {
            velX *= left ? -1 : 1;
            velZ = 0;
            Debug.Log("horizontal");

        }
        else if ((up || down) && (!right && !left))
        {
            velZ *= down ? -1 : 1;
            velX = 0;
            Debug.Log("vertical");

        }
        else
        {
            velX = 0;
            velZ = 0;
            Debug.Log("nothing");

        }
        body.velocity = new Vector3(velX, body.velocity.y, velZ);
	}
}
