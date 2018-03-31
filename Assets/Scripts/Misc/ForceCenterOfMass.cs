using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Forces a rigid body to use a particular center of mass
public class ForceCenterOfMass : MonoBehaviour {

    public Vector3 CenterOfMass;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().centerOfMass = CenterOfMass;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
