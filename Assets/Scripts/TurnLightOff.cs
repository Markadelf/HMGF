using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightOff : MonoBehaviour {

	//add to directional light in scene
	//turns off light when game starts

	private Light myDirectionalLight;

	// Use this for initialization
	void Start() 
	{
		myDirectionalLight = gameObject.GetComponent<Light>();
		myDirectionalLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}
}
