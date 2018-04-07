using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNearPlayer : MonoBehaviour {

	private GameObject player;
	[SerializeField] private float soundRadius;
	private AudioSource mySound;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		mySound = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		float distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);

		if (distanceFromPlayer > soundRadius)
		{
			mySound.volume = 0.0f;
		}
		else
		{
			mySound.volume = 1.0f - (distanceFromPlayer/soundRadius);
		}
	}
}
