using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFadeMusic : MonoBehaviour {

	public AudioSource song1;
	public AudioSource song2;
	public AudioSource currentSong;

	public bool goingToSong1;


	// Use this for initialization
	void Start() 
	{
		song1 = GameObject.FindGameObjectWithTag("ManorMusic").GetComponent<AudioSource>();
        song2 = GameObject.FindGameObjectWithTag("InnerRoomsMusic").GetComponent<AudioSource>();
        currentSong = song1;
		goingToSong1 = true;
		song1.Play();
	}
	
	// Update is called once per frame
	void Update() 
	{
		//if the current song is song 1....
		if (currentSong == song1)
		{
			//pump up song 1 and pump down song 2
			if (song1.volume < 1.0f)
			{
				song1.volume += 0.01f;
			}
			//don't break ears
			if (song1.volume > 1.0f)
			{
				song1.volume = 1.0f;
			}
			song2.volume = 1.0f - song1.volume;
		}
		//if it's song 2...
		else
		{
			//pump up song 2 and pump down song 1
			if (song2.volume < 1.0f)
			{
				song2.volume += 0.01f;
			}
			//don't break ears
			if (song2.volume > 1.0f)
			{
				song2.volume = 1.0f;
			}
			song1.volume = 1.0f - song2.volume;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//check if the trigger volume has an AudioSource
		if (other.gameObject.GetComponent<AudioSource>() != null)
		{
			//if it does, and you're playing song 1, make song2 the new song
			if (currentSong == song1)
			{
				//first turn off old sounds
				if (song2 != null)
				{
					song2.volume = 0.0f;
				}
				//then set up new ones
				song2 = other.gameObject.GetComponent<AudioSource>();
				currentSong = song2;
				currentSong.Play();
			}
			//if you're playing song 2, make song1 the new song
			else
			{
				//first turn off old sounds
				if (song1 != null)
				{
					song1.volume = 0.0f;
				}
				//then set up new ones
				song1 = other.gameObject.GetComponent<AudioSource>();
				currentSong = song1;
				currentSong.Play();
			}
		}
	}
}
