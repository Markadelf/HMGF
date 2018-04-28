using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Grabable {


	private float timeTillReclick;
	private float timer;
	//determines if the door is locked
	public bool isLocked;
	//determines if the door is currently closed
	private bool doorClosed;
	private bool doorClosedSoundPlayed;
	public GameObject player;
	//determines if the door opens clockwise from above
	public bool clockwise;

	public float startYRot;
	public float currYRot;

	// Use this for initialization
	void Start() 
	{
        GrabType = GrabAnimation.Door;
		timeTillReclick = 60.0f;
		timer = 0.0f;
		doorClosed = true;
		doorClosedSoundPlayed = true;
		startYRot = transform.eulerAngles.y;
		currYRot = startYRot;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Vector3.Distance(player.transform.position, transform.position) < 4.0f && Input.GetAxis("Interact") > 0 && timer > timeTillReclick)
		{
            if (!isLocked)
            {
                doorClosed = !doorClosed;
                timer = 0.0f;

                //if opening the door, play the open door sound, and make available the close door sound
                if (!doorClosed)
                {
                    AudioSource doorOpenSound = GameObject.FindGameObjectWithTag("DoorOpen").GetComponent<AudioSource>();
                    doorOpenSound.Play();
                    doorClosedSoundPlayed = false;
                }
            }
            //if a player tries to open the door when it is locked, play the sound effect
            else
            {
                AudioSource doorLockedSound = GameObject.FindGameObjectWithTag("DoorLocked").GetComponent<AudioSource>();
                doorLockedSound.Play();
            }
        }
		

		if (!clockwise)
		{
			if (doorClosed && currYRot < startYRot)
			{
				currYRot += Time.deltaTime * 50.0f;
			}
			else if (!doorClosed && currYRot > startYRot - 90.0f)
			{
				currYRot -= Time.deltaTime * 50.0f;
			}
			//when the door shuts, play the close sound effect; the door must be opened to play it again
			else if (doorClosed && currYRot >= startYRot && !doorClosedSoundPlayed)
			{
				AudioSource doorCloseSound = GameObject.FindGameObjectWithTag("DoorClose").GetComponent<AudioSource>();
				doorCloseSound.Play();
				doorClosedSoundPlayed = true;
			}
		} 
		else
		{
			if (doorClosed && currYRot > startYRot)
			{
				currYRot -= Time.deltaTime * 50.0f;
			} 
			else if (!doorClosed && currYRot < startYRot + 90.0f)
			{
				currYRot += Time.deltaTime * 50.0f;
			}
			//when the door shuts, play the close sound effect; the door must be opened to play it again
			else if (doorClosed && currYRot <= startYRot && !doorClosedSoundPlayed)
			{
				AudioSource doorCloseSound = GameObject.FindGameObjectWithTag("DoorClose").GetComponent<AudioSource>();
				doorCloseSound.Play();
				doorClosedSoundPlayed = true;
			} 
		}

		transform.rotation = Quaternion.Euler(transform.rotation.x, currYRot, transform.rotation.z);

		timer++;
	}

	private void PlayOpenDoor()
	{

	}

	private void PlayCloseDoor()
	{

	}

    public void UnlockDoor()
    {
        isLocked = false;
    }

    public override void Grab(GameObject grabber)
    {
        if (!isLocked)
        {
            doorClosed = !doorClosed;
            timer = 0.0f;

            //if opening the door, play the open door sound, and make available the close door sound
            if (!doorClosed)
            {
                AudioSource doorOpenSound = GameObject.FindGameObjectWithTag("DoorOpen").GetComponent<AudioSource>();
                doorOpenSound.Play();
                doorClosedSoundPlayed = false;
            }
        }
        //if a player tries to open the door when it is locked, play the sound effect
        else
        {
            AudioSource doorLockedSound = GameObject.FindGameObjectWithTag("DoorLocked").GetComponent<AudioSource>();
            doorLockedSound.Play();
        }
    }

    public override void Release()
    {
    }
}
