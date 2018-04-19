using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StochasticSound : MonoBehaviour {

	private float timer;
	private float chance;

	public float frequency;

	// Use this for initialization
	void Start() 
	{
		timer = 0.0f;
		chance = 0.0f;
	}
	
	// Update is called once per frame
	void Update() 
	{
		float rand = Random.value;

		if (rand < chance)
		{
			AudioSource mySound = gameObject.GetComponent<AudioSource>();
			mySound.Play();
			chance = 0.0f;
		}


		timer += Time.deltaTime;
		chance += Time.deltaTime * 0.00001f * frequency;
	}
}
