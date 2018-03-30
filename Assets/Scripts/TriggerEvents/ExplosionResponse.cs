using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionResponse : TriggerEvent {

    ParticleSystem exp;
    public override void Activate()
    {
        exp.Play();
    }

    public override void Activate(bool state)
    {
        if(state)
            Activate();
    }

    public override void Activate(int state)
    {
        Activate(state != 0);
    }

    // Use this for initialization
    void Start () {
        exp = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
