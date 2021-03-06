﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A distance based trigger mechanism
public class ProximityTrigger : Trigger {

    public GameObject Target;
    public float Range;
    public bool Once = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Target != null && (Target.transform.position - transform.position).sqrMagnitude < Range * Range)
        {
            Activate(true);
            if (Once)
                enabled = false;
        }
        else
        {
            Activate(false);
        }
    }
}
