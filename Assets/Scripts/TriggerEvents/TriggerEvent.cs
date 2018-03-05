using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void Activate();

    public abstract void Activate(bool state);

    public abstract void Activate(int state);

}
