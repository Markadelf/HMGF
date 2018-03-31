using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPosing : MonoBehaviour {

	[SerializeField] private GameObject player;

	public bool puzzleSolved;

	private float scaleComponent;

	// Use this for initialization
	void Start () 
	{
		scaleComponent = 1.0f;
		puzzleSolved = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//positioning is correct
		if (transform.position.x > player.transform.position.x - scaleComponent && transform.position.x < player.transform.position.x + scaleComponent
		    && transform.position.z > player.transform.position.z - scaleComponent && transform.position.z < player.transform.position.z + scaleComponent
			&& player.transform.position.y > transform.position.y)
		{
			//TODO: check if the player is posing
			if (true)
			{
				puzzleSolved = true;
			}
		}
		print (puzzleSolved);
	}
}
