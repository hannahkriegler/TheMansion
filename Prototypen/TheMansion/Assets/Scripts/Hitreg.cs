using UnityEngine;
using System.Collections;

public class Hitregistration : MonoBehaviour
{

    /* Zur Nutzung dieses Scripts: 
     * Hier wird davon ausgegangen, dass der Name des Scripts in den Geistern "Move" und die Bewegungsflag "seen" heißt. Des weiteren gehe ich davon aus, dass jeder Geist den Tag "Ghost" besitzt.
     * Falls dem nicht so ist sollte dies im Code angepasst werden.
     */
    // Hierbei handelt es sich um die Taschenlampe des Spielers. Da es eine public Variable ist bitte in Unity reinziehen.
    public Light flashlight;
    private GameObject[] targets;
    private ArrayList scripts;

    // Use this for initialization
    void Start()
    {
        scripts = new ArrayList();
        targets = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject o in targets)
        {
            scripts.Add(o.GetComponent<SimpleMovement>());
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Falls an keiner weiteren Stelle die Taschenlampe an- bzw ausgestellt werden kann, kann das folgende Codesegment wieder aktiviert werden.

        
       if (Input.GetMouseButtonDown(0))
       {   // aktiviert, bzw deaktiviert die Taschenlampe per linksklick.
           flashlight.enabled = !flashlight.enabled;
       }
       

        RaycastHit hit;
        if (Physics.Raycast(flashlight.transform.position, flashlight.transform.forward, out hit) && flashlight.enabled)
        {
            if (hit.collider.tag == "Ghost")
            {
                SimpleMovement movementScript = hit.collider.GetComponent<SimpleMovement>();

                movementScript.seen = true;

            }
            else
            {
                foreach (SimpleMovement o in scripts)
                {
                    o.seen = false;
                }
            }
        }
        else
        {
            foreach (SimpleMovement o in scripts)
            {
                o.seen = false;
            }
        }
    }
}