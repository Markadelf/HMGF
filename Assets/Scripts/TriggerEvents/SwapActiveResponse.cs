using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This event is used to seemlessly make one object active, and another inactive
/// </summary>
public class SwapActiveResponse : TriggerEvent {

    public GameObject ObjectA;
    public GameObject ObjectB;
    private bool _state;

    public override void Activate()
    {
        _state = !_state;
        ObjectA.SetActive(_state);
        ObjectB.SetActive(!_state);
    }

    public override void Activate(bool state)
    {
        _state = state;
        ObjectA.SetActive(_state);
        ObjectB.SetActive(!_state);
    }

    public override void Activate(int state)
    {
        Activate(state != 0);
    }

    // Use this for initialization
    void Start () {
        Activate(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
