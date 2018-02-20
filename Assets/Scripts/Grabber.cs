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
		if(isGrabObject && (!Input.GetButton("14") && !Input.GetButton("15")))
        {
            grabbedObject.Release();
            isGrabObject = false;
        }
	}

    private void OnCollisionStay(Collision collision)
    {
        if (isGrabObject) return;

        if(Input.GetButton("14") || Input.GetButton("15"))
        {
            grabbedObject = collision.gameObject.GetComponent<Grabable>();

            if (grabbedObject == null) return;

            grabbedObject.Grab(gameObject);

            isGrabObject = true;
        }
    }
}
