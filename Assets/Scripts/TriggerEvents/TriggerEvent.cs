using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The template for a triggered event withing the trigger system.
/// </summary>
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
