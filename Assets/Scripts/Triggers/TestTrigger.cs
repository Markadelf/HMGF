using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple test trigger that activates with a keypress
/// </summary>
public class TestTrigger : Trigger {

    public KeyCode key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key))
        {
            Activate();
        }
	}
}
