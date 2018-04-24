using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Replaces one object with another. Object must be in the scene
public class Burnable : TriggerEvent {

    public GameObject Result;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Activate()
    {
        Result.SetActive(true);
        Result.transform.position = transform.position;
        Result.transform.rotation = transform.rotation;
        gameObject.SetActive(false);
    }

    public override void Activate(bool state)
    {
        if (state)
            Activate();
    }

    public override void Activate(int state)
    {
        Activate(state > 0);
    }
}
