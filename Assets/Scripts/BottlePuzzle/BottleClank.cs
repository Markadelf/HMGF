using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleClank : Grabable {

	public Camera myCamera;
	private float timer;
	private float timeTillReclick;
	public int whichBottle;
	AudioSource mySound;

	// Use this for initialization
	void Start() 
	{
		timer = 0.0f;
		timeTillReclick = 0.3f;
        GrabType = GrabAnimation.Point;
		mySound = gameObject.GetComponentInChildren<AudioSource>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Input.GetAxis("Interact") > 0 && timer > timeTillReclick && !character.VR)
		{
			Ray mouseToObj = myCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastInfo;
			bool didHit = Physics.Raycast(mouseToObj, out raycastInfo, 100.0f);
			if (didHit && raycastInfo.collider.gameObject == gameObject)
			{
                print("Bap!");
				BottlePuzzleManager.HitBottle(whichBottle);
				mySound.Play();
			}

			timer = 0.0f;
		}

		timer += Time.deltaTime;
	}

    public override void Grab(GameObject grabber)
    {
        BottlePuzzleManager.HitBottle(whichBottle);
        mySound.Play();
    }

    public override void Release()
    {

    }
}
