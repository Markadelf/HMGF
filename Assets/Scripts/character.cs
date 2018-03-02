using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

    public float speed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Left Hand  X = Axis 1 y = Axis 2
        //Right Hand x = Axis 4 y = Axis 5

        //Will test and implement!

		if (Input.GetAxis("Vertical") > 0)
		{
			transform.position += transform.forward * Time.deltaTime * speed;
		}
		if (Input.GetAxis("Vertical") < 0)
		{
			transform.position -= transform.forward * Time.deltaTime * speed;
		}
		if (Input.GetAxis("Horizontal") > 0) 
		{
			transform.Rotate(transform.up * 70.0f * Time.deltaTime);
		}
		if (Input.GetAxis("Horizontal") < 0) 
		{
			transform.Rotate(-transform.up * 70.0f * Time.deltaTime);
		}
	}
}
