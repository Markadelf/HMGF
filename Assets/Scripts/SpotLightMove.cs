using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightMove : MonoBehaviour {

	[SerializeField] private float minPitch;
	[SerializeField] private float maxPitch;
	[SerializeField] private float currPitch;

	//determines if the axis is x, y, or z
	//1 = x, 2 = y, 3 = z
	[SerializeField] private int whichRotationAxis;

	private float timer;
	private float timeToChange;
	private float timeVariability;
	private float randSeed;
	private float moveSpeed;

	private bool direction;

	// Use this for initialization
	void Start() 
	{
		timer = 0.0f;
		timeToChange = 1.5f;
		timeVariability = 0.5f;
		randSeed = Random.value * 2.0f * timeVariability -  timeVariability;
		direction = true;
		moveSpeed = 0.1f;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (timer > timeToChange + randSeed)
		{
			direction = !direction;
			randSeed = Random.value * 2.0f * timeVariability -  timeVariability;

			timer = 0.0f;
		}

		if (currPitch >= maxPitch)
		{
			direction = !direction;
			timer = 0.0f;
		}
		if (currPitch <= minPitch)
		{
			direction = !direction;
			timer = 0.0f;
		}

		if (whichRotationAxis == 1)
		{
			if (direction)
			{
				transform.Rotate(Vector3.right * moveSpeed);
				currPitch += moveSpeed;
			}
			else
			{
				transform.Rotate(Vector3.right * -moveSpeed);
				currPitch -= moveSpeed;
			}
		}
		else if (whichRotationAxis == 2)
		{
			if (direction)
			{
				transform.Rotate(Vector3.up * moveSpeed);
				currPitch += moveSpeed;
			}
			else
			{
				transform.Rotate(Vector3.up * -moveSpeed);
				currPitch -= moveSpeed;
			}
		}
		else
		{
			if (direction)
			{
				transform.Rotate(Vector3.forward * moveSpeed);
				currPitch += moveSpeed;
			}
			else
			{
				transform.Rotate(Vector3.forward * -moveSpeed);
				currPitch -= moveSpeed;
			}
		}

		timer += Time.deltaTime;
	}
}
