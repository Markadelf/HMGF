using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : Trigger {

    public GameObject Target;
    public float Range;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if((Target.transform.position - transform.position).sqrMagnitude < Range * Range)
        {
            Activate(true);
        }
	}
}
