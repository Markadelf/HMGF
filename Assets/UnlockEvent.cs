using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockEvent : TriggerEvent {

    OpenDoor _door;

	// Use this for initialization
	void Start () {
        _door = GetComponent<OpenDoor>();
        _door.isLocked = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Activate()
    {
        _door.isLocked = false;
    }

    public override void Activate(bool state)
    {
        _door.isLocked = !state;
    }

    public override void Activate(int state)
    {
        Activate(state > 0);
    }
}
