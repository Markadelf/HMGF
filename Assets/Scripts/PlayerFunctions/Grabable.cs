using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    Transform normalParent;
    Rigidbody ObjectRigidbody;
	
	void Start ()
    {
		ObjectRigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	
	void Update ()
    {
		
	}

    public virtual void Grab(GameObject grabber)
    {
        normalParent = transform.parent;

        transform.parent = grabber.transform;

        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        if(ObjectRigidbody != null) { ObjectRigidbody.useGravity = false; }
    }

    public virtual void Release()
    {
        transform.parent = normalParent;

        gameObject.GetComponent<Rigidbody>().isKinematic = false;

        if (ObjectRigidbody != null) { ObjectRigidbody.useGravity = true; }
    }
}
