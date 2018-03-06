using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    bool isGrabObject;
    Grabable grabbedObject;

	void Start ()
    {
        isGrabObject = false;
	}
	
	
	void Update ()
    {
		//if(isGrabObject && ((!Input.GetButton("14") && !Input.GetButton("15"))) || Input.GetKey(KeyCode.Backspace))
        if(isGrabObject && Input.GetKey(KeyCode.Backspace))
        {
            grabbedObject.Release();
            isGrabObject = false;
        }
    }
    
    private void OnTriggerStay(Collider collision)
    {
        if (isGrabObject) return;

        //if(Input.GetButton("14") || Input.GetButton("15") || Input.GetKey(KeyCode.Space))
        if(Input.GetKey(KeyCode.Space))
        {
            grabbedObject = collision.gameObject.GetComponent<Grabable>();

            if (grabbedObject == null) return;

            grabbedObject.Grab(gameObject);

            isGrabObject = true;
        }
    }
}
