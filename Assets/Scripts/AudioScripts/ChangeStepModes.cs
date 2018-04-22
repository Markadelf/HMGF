using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStepModes : MonoBehaviour {

	//use 0 for basic, 1 for bathroom, 2 for crunchy, 3 for metal, and 4 for rubble
	[SerializeField] private int stepType; 

	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<character>().SetStepType(stepType);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<character>().SetStepType(0);
		}
	}
}
