using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    public Camera cam;
    public Light Flashlight;
    public float speed = 0.05f;
    public bool seen = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!seen)
        {
            transform.Translate(0, 0, 0.05f);
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
