using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadButton : Grabable {

    public int Value;
    public bool pressed;
    private float _originalZ;

	// Use this for initialization
	void Start () {
        _originalZ = transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
        if (pressed)
        {
            transform.localPosition += new Vector3(0, 0, -.01f); 
        }
        else if (transform.localPosition.z < _originalZ)
        {
            transform.localPosition += new Vector3(0, 0, .01f);
        }
        if(transform.localPosition.z < .1f)
        {
            pressed = false;
        }
        
	}

    public override void Grab(GameObject grabber)
    {
        pressed = true;
        if (KeyPadManager.active != null)
            KeyPadManager.active.Notify(Value);
        
    }

    public override void Release()
    {
    }

}
