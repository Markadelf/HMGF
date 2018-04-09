using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Grabable {


	private float timeTillReclick;
	private float timer;
	//determines if the door is locked
	[SerializeField] private bool isLocked;
	//determines if the door is currently closed
	private bool doorClosed;
	public GameObject player;
	//determines if the door opens clockwise from above
	public bool clockwise;

	public float startYRot;
	public float currYRot;

	// Use this for initialization
	void Start() 
	{
		timeTillReclick = 60.0f;
		timer = 0.0f;
		doorClosed = true;
		startYRot = transform.eulerAngles.y;
		currYRot = startYRot;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Vector3.Distance(player.transform.position, transform.position) < 4.0f && Input.GetAxis("Interact") > 0 && timer > timeTillReclick && !isLocked)
		{
			doorClosed = !doorClosed;
			timer = 0.0f;
		}

		if (!clockwise)
		{
			if (doorClosed && currYRot < startYRot)
			{
				currYRot++;
			} 
			else if (!doorClosed && currYRot > startYRot - 90.0f)
			{
				currYRot--;
			}
		} 
		else
		{
			if (doorClosed && currYRot > startYRot)
			{
				currYRot--;
			} 
			else if (!doorClosed && currYRot < startYRot + 90.0f)
			{
				currYRot++;
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

    public override void Grab(GameObject grabber)
    {
        doorClosed = !doorClosed;
    }

    public override void Release()
    {
    }
}
