using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : EaseToLocation
{
    Transform normalParent;
    Rigidbody ObjectRigidbody;
	
	void Start ()
    {
		ObjectRigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	

    public virtual void Grab(GameObject grabber)
    {
        normalParent = transform.parent;

        transform.parent = grabber.transform;

        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        if(ObjectRigidbody != null) { ObjectRigidbody.useGravity = false; }
        Move(grabber.transform.position, 10);
    }

    public virtual void Release()
    {
        transform.parent = normalParent;

        gameObject.GetComponent<Rigidbody>().isKinematic = false;

        if (ObjectRigidbody != null) { ObjectRigidbody.useGravity = true; }
    }
}
