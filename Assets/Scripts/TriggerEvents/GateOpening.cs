using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpening : TriggerEvent {

    private bool _state;
    private Collider _collider;
    private Renderer _renderer;

    public override void Activate()
    {
        Set(!_state);
    }

    public override void Activate(bool state)
    {
        Set(!state);
    }

    public override void Activate(int state)
    {
        Set(state == 0);
    }

    // Use this for initialization
    void Start () {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Set(bool state)
    {
        _state = state;
        _collider.enabled = _state;
        _renderer.enabled = _state;
    }
}
