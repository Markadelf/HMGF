using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleClank : MonoBehaviour {

	public Camera myCamera;
	private float timer;
	private float timeTillReclick;
	public int whichBottle;
	AudioSource mySound;

	// Use this for initialization
	void Start() 
	{
		timer = 0.0f;
		timeTillReclick = 30.0f;
		mySound = gameObject.GetComponent<AudioSource>();
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
				//print("Clicked!");
				BottlePuzzleManager.HitBottle(whichBottle);
				mySound.Play();
			}

			timer = 0.0f;
		}

		timer++;
	}
}
