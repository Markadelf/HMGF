using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : TriggerEvent {
    public float speed;

    public override void Activate()
    {
        enabled = true;
    }

    public override void Activate(bool state)
    {
        enabled = state;
    }

    public override void Activate(int state)
    {
        enabled = state > 0;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
	}
}
