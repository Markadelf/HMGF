﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A proximity trigger that holds an object once it triggers.
public class PlacementTrigger : ProximityTrigger {
    Vector3 _vel;
    int _time = -1;
    public int maxTime = 10;
    Quaternion _original;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Target != null && (Target.transform.position - transform.position).sqrMagnitude < Range * Range)
        {
            Activate(true);
            Target.transform.parent = transform;
            _time = maxTime;
            _vel = -Target.transform.localPosition / _time;
            _original = Target.transform.localRotation;

            //Deactivate pesky things
            var grab = Target.GetComponent<Grabable>();
            if(grab != null) grab.enabled = false;
            var rigid = Target.GetComponent<Rigidbody>();
            if(rigid != null) { rigid.useGravity = false; rigid.isKinematic = true; }
        }

        //If we've nabbed the object, slowly move it towards you
        if(_time != -1)
        {
            Target.transform.localPosition += _vel;
            Target.transform.localRotation = Quaternion.Slerp(Quaternion.identity, _original, ((float)_time) / maxTime);

            if (_time == 0)
            {
                this.enabled = false;
                Target.transform.localPosition = new Vector3();
            }
        }
    }
}
