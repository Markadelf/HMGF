using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleRight : MonoBehaviour {

	[SerializeField] private GameObject doorRight;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject scaleLeft;
	public bool active;
	[SerializeField] private bool leftActive;
	[SerializeField] private bool goingUp;
	[SerializeField] private bool goingDown;
	[SerializeField] private float startingYPos;

	// Use this for initialization
	void Start () {
		startingYPos = transform.position.y;
		player = GameObject.FindGameObjectWithTag("Player");
		doorRight = GameObject.FindGameObjectWithTag("ScaleDoorRight");
		active = false;
		scaleLeft = GameObject.FindGameObjectWithTag("ScaleLeft");
		leftActive = false;
		goingUp = false;
		goingDown = false;
	}

	// Update is called once per frame
	void Update () {
		//keep track of what active is at the beginning to use later
		bool prevActive = active;
		leftActive = scaleLeft.active;
		//only one lever can be down at a time
		if (leftActive == true) 
		{
			active = false;
		}
		float distance = Vector3.Distance (transform.position, player.transform.position);
		float leftDistance = Vector3.Distance (scaleLeft.transform.position, player.transform.position);
		//if you are close enough to the lever and press space
		if (distance < 2.0 && Input.GetAxis("Interact") > 0 && distance < leftDistance)
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
			transform.position += transform.up * Time.deltaTime;
		} 
		else 
		{
			goingDown = false;
		}
	}
}
