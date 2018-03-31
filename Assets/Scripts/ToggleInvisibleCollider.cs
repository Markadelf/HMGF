using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInvisibleCollider : MonoBehaviour {

	[SerializeField] private GameObject pedistool;

	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (pedistool.GetComponent<PlatformPosing>().puzzleSolved)
		{
			gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
