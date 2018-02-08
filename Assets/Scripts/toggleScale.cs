using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleScale : MonoBehaviour {

	[SerializeField] private GameObject doorLeft;
	[SerializeField] private GameObject doorRight;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject scaleLeft;
	[SerializeField] private GameObject scaleRight;
	//0: inactive, 1: left active, 2: right active
	public int state;
	[SerializeField] private float startingYPosLeft;
	[SerializeField] private float startingYPosRight;
	[SerializeField] private float startingRotationDoorLeft;
	[SerializeField] private float startingRotationDoorRight;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		doorRight = GameObject.FindGameObjectWithTag("ScaleDoorRight");
		doorLeft = GameObject.FindGameObjectWithTag("ScaleDoorLeft");
		state = 0;
		scaleLeft = GameObject.FindGameObjectWithTag("ScaleLeft");
		scaleRight = GameObject.FindGameObjectWithTag("ScaleRight");
		startingYPosLeft = scaleLeft.transform.position.y;
		startingYPosRight = scaleRight.transform.position.y;
		startingRotationDoorLeft = doorLeft.transform.rotation.y * Mathf.PI / 180.0f;
		startingRotationDoorRight = doorRight.transform.rotation.y * Mathf.PI / 180.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float rightDistance = Vector3.Distance (scaleRight.transform.position, player.transform.position);
		float leftDistance = Vector3.Distance (scaleLeft.transform.position, player.transform.position);
		//if you are close enough to the lever and press space
		if ((leftDistance < 3.0 || rightDistance < 3.0) && Input.GetAxis("Interact") > 0 && leftDistance < rightDistance)
		{
			//set left lever to go down
			state = 1;
		}
		if ((leftDistance < 3.0 || rightDistance < 3.0) && Input.GetAxis("Interact") > 0 && leftDistance > rightDistance)
		{
			//set right lever to go down
			state = 2;
		}

		//if the lever is supposed to be down, move it down
		if (state == 1 && scaleLeft.transform.position.y > startingYPosLeft - 0.2) 
		{
			scaleLeft.transform.position -= scaleLeft.transform.up * Time.deltaTime;
		} 
		//if the lever is supposed to be up, move it up
		else if (state != 1 && scaleLeft.transform.position.y < startingYPosLeft) 
		{
			scaleLeft.transform.position += scaleLeft.transform.up * Time.deltaTime;
		}

		//if the lever is supposed to be down, move it down
		if (state == 2 && scaleRight.transform.position.y > startingYPosRight - 0.2) 
		{
			scaleRight.transform.position -= scaleRight.transform.up * Time.deltaTime;
		} 
		//if the lever is supposed to be up, move it up
		else if (state != 2 && scaleRight.transform.position.y < startingYPosRight) 
		{
			scaleRight.transform.position += scaleRight.transform.up * Time.deltaTime;
		}

		//if the door needs to open, open it
		if (state == 1 && doorLeft.transform.rotation.y > startingRotationDoorLeft - (1.0f / 1.5f)) 
		{
			doorLeft.transform.Rotate(-doorLeft.transform.up * Time.deltaTime * 40.0f);
		}
		//if the door needs to be closed, close it
		else if (state != 1 && doorLeft.transform.rotation.y < startingRotationDoorLeft) 
		{
			doorLeft.transform.Rotate(doorLeft.transform.up * Time.deltaTime * 40.0f);
		}

		//if the door needs to open, open it
		if (state == 2 && doorRight.transform.rotation.y < startingRotationDoorRight + (1.0f / 1.5f)) 
		{
			doorRight.transform.Rotate(doorRight.transform.up * Time.deltaTime * 40.0f);
		}
		//if the door needs to be closed, close it
		else if (state != 2 && doorRight.transform.rotation.y > startingRotationDoorRight) 
		{
			doorRight.transform.Rotate(-doorRight.transform.up * Time.deltaTime * 40.0f);
		}


		Debug.Log(doorLeft.transform.rotation.y);
		Debug.Log(startingRotationDoorLeft - Mathf.PI / 2.0f);
	}
}
