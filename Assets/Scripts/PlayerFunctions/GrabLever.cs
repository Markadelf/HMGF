using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            _lever.Flip();
    }

    public override void Release()
    {

    }
}
