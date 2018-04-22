using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Activates a deactive object
/// </summary>
public class ActivateResponse : TriggerEvent {

    public GameObject Target;

    public override void Activate()
    {
        Target.SetActive(true);
    }

    public override void Activate(bool state)
    {
        Target.SetActive(state);
    }

    public override void Activate(int state)
    {
        Activate(state != -1);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
