using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Vertical") > 0)
		{
			transform.position += transform.forward * Time.deltaTime;
		}
		if (Input.GetAxis("Vertical") < 0)
		{
			transform.position -= transform.forward * Time.deltaTime;
		}
		if (Input.GetAxis("Horizontal") > 0) 
		{
			transform.Rotate(transform.up * 40.0f * Time.deltaTime);
		}
		if (Input.GetAxis("Horizontal") < 0) 
		{
			transform.Rotate(-transform.up * 40.0f * Time.deltaTime);
		}
	}
}
