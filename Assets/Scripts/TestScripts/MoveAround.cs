using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour 
{

	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Input.GetAxis("Horizontal") > 0)
		{
			transform.position += new Vector3(Time.deltaTime, 0.0f, 0.0f);
		}
		else if (Input.GetAxis("Horizontal") < 0)
		{
			transform.position += new Vector3(-Time.deltaTime, 0.0f, 0.0f);
		}

		if (Input.GetAxis("Vertical") > 0)
		{
			transform.position += new Vector3(0.0f, 0.0f, Time.deltaTime);
		}
		if (Input.GetAxis("Vertical") < 0)
		{
			transform.position += new Vector3(0.0f, 0.0f, -Time.deltaTime);
		}
	}
}
