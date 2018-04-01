using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObjects : MonoBehaviour {

	public Camera myCamera;

	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Input.GetAxis("Interact") > 0)
		{
			Ray mouseToObj = myCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastInfo;
			bool didHit = Physics.Raycast (mouseToObj, out raycastInfo, 10.0f);
			if (didHit)
			{
				//print (raycastInfo.collider.name + "   " + raycastInfo.point);
			} 
			else
			{
				//print("Empty space!");
			}
		}
	}
}
