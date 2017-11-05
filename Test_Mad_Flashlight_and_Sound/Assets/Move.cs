using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    public Camera cam;
    public Light Flashlight;
    public float speed = 0.05f;
    private bool seen = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!seen)
        {
            transform.Translate(0, 0, 0.05f);
        }

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit) && Flashlight.enabled)
        {
            if (hit.collider.tag == "Ghost")
            {
                seen = true;
            }
        } else
        {
            seen = false;
        }



    } 


    void OnCollisionEnter(Collision collider)
    {
        GameObject target = collider.gameObject;
        if (target.tag.Equals("Wall"))
        {

            transform.Rotate(0, 90, 0);
        }
        
    }
   
    
    
}
