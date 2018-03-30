using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotateButChillItsForATest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") > 0) 
		{
			transform.Rotate(transform.up * 70.0f * Time.deltaTime);
		}
		else if (Input.GetAxis("Horizontal") < 0) 
		{
			transform.Rotate(transform.up * -70.0f * Time.deltaTime);
		}
	}
}
