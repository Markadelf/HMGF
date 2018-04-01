using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreakerPuzzle : MonoBehaviour {

	public Camera myCamera;
	private float timer;
	private float timeTillReclick;
	[SerializeField] private GameObject[] allSwitchedSwitches;
	[SerializeField] private Material offMaterial;
	[SerializeField] private Material onMaterial;

	// Use this for initialization
	void Start() 
	{
		timer = 0.0f;
		timeTillReclick = 30.0f;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Input.GetAxis("Interact") > 0 && timer > timeTillReclick)
		{
			Ray mouseToObj = myCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastInfo;
			bool didHit = Physics.Raycast(mouseToObj, out raycastInfo, 10.0f);
			if (didHit && raycastInfo.collider.gameObject == gameObject)
			{
				for (int i = 0; i < allSwitchedSwitches.GetLength(0); i++)
				{
					allSwitchedSwitches[i].GetComponent<StoreNumTicks>().numTicks++;
					if (allSwitchedSwitches[i].GetComponent<StoreNumTicks>().numTicks % 2 == 1)
					{
						allSwitchedSwitches[i].GetComponent<MeshRenderer>().material = onMaterial;
					}
					else
					{
						allSwitchedSwitches[i].GetComponent<MeshRenderer>().material = offMaterial;
					}
				}
			}

			timer = 0.0f;
		}

		timer++;
	}
}
