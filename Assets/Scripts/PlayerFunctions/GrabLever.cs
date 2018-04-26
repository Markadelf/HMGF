using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flips the lever on this object when it is grabbed
public class GrabLever : Grabable {

    //My lever refference
    Lever _lever;

	// Use this for initialization
	void Start () {
        _lever = GetComponent<Lever>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Grab(GameObject grabber)
    {
        if (_lever != null)
        {
            _lever.Flip();
            if(!_lever.GetState())
                _lever.Flip();
        }
    }

    public override void Release()
    {

    }
}
