using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleLeft : MonoBehaviour {

	[SerializeField] private GameObject doorLeft;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject scaleRight;
	public bool active;
	[SerializeField] private bool rightActive;
	[SerializeField] private bool goingUp;
	[SerializeField] private bool goingDown;
	[SerializeField] private float startingYPos;

	// Use this for initialization
	void Start () {
		startingYPos = transform.position.y;
		player = GameObject.FindGameObjectWithTag("Player");
		doorLeft = GameObject.FindGameObjectWithTag("ScaleDoorLeft");
		active = false;
		scaleRight = GameObject.FindGameObjectWithTag("ScaleRight");
		rightActive = false;
		goingUp = false;
		goingDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		//keep track of what active is at the beginning to use later
		bool prevActive = active;
		rightActive = scaleRight.active;
		//only one lever can be down at a time
		if (rightActive == true) 
		{
			active = false;
		}
		float distance = Vector3.Distance (transform.position, player.transform.position);
		float rightDistance = Vector3.Distance (scaleRight.transform.position, player.transform.position);
		//if you are close enough to the lever and press space
		if (distance < 2.0 && Input.GetAxis("Interact") > 0 && distance < rightDistance)
		{
			active = true;
		}

		//if a lever has changed its state...
		if (!prevActive && active) 
		{
			goingDown = true;
		}

		if (prevActive && !active) 
		{
			goingUp = true;
		}

		//play going down
		if (goingDown && transform.position.y > startingYPos - 0.2) 
		{
			transform.position -= transform.up * Time.deltaTime;
		} 
		else 
		{
			goingDown = false;
		}

		//play going up
		if (goingUp && transform.position.y < startingYPos) 
		{
			transform.position += transform.up * Time.deltaTime * 0.01f;
		} 
		else 
		{
			goingDown = false;
		}

		Debug.Log(distance);
		Debug.Log(transform.up);
	}
}
