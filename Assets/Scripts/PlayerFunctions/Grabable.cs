using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : EaseToLocation
{
    Transform normalParent;
    Rigidbody ObjectRigidbody;
    bool grabbed;
	
	void Start ()
    {
		ObjectRigidbody = gameObject.GetComponent<Rigidbody>();
        grabbed = false;
    }
	
	

    public virtual void Grab(GameObject grabber)
    {
        if (!enabled || grabbed)
            return;
        normalParent = transform.parent;

        transform.parent = grabber.transform;

        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        if(ObjectRigidbody != null) { ObjectRigidbody.useGravity = false; }
        Move(grabber.transform.position, 10);
        grabbed = true;
    }

    public virtual void Release()
    {
        if (!enabled || !grabbed || gameObject == null)
            return;
        transform.parent = normalParent;

        gameObject.GetComponent<Rigidbody>().isKinematic = false;

        if (ObjectRigidbody != null) { ObjectRigidbody.useGravity = true; }
        grabbed = false;
    }
}
