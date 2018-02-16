using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    Transform normalParent;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    public void Grab(GameObject grabber)
    {
        normalParent = transform.parent;

        transform.parent = grabber.transform;
    }

    public void Release()
    {
        transform.parent = normalParent;
    }
}
