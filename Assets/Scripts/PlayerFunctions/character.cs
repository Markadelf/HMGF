using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {


	//use 0 for basic, 1 for bathroom, 2 for crunchy, 3 for metal, and 4 for rubble
	[SerializeField] private int stepType;

	public AudioSource[] basicSteps;
	public AudioSource[] bathroomSteps;
	public AudioSource[] crunchySteps;
	public AudioSource[] metalSteps;
	public AudioSource[] rubbleSteps;

    public float speed = 5;
    //The camera
    public GameObject head;
    //The rig
    public GameObject rig;

    // Use this for initialization
    void Start() 
	{
		stepType = 0;	
	}
	
	// Update is called once per frame
	void Update () {
        //Left Hand  X = Axis 1 y = Axis 2
        //Right Hand x = Axis 4 y = Axis 5

        //Will test and implement!
        float thrust = Input.GetAxis("Vertical");
        if (head != null)
        {
            if (thrust != 0)
            {
                Vector3 direction = head.transform.forward;
                if (direction.x == 0 && direction.z == 0)
                {
                    direction = -head.transform.up;
                }
                direction.y = 0;
                direction.Normalize();
                if (thrust > 0)
                {
                    transform.position += direction * Time.deltaTime * speed;
                }
                if (thrust < 0)
                {
                    transform.position -= direction * Time.deltaTime * speed;
                }

				//since you are moving, play a random footstep sound effect
				//basic
				if (stepType == 0 && basicSteps.GetLength(0) > 0)
				{
					PlayRandomSound(basicSteps);
				}
				//bathroom
				else if (stepType == 1 && bathroomSteps.GetLength(0) > 0)
				{
					PlayRandomSound(bathroomSteps);
				}
				//crunchy
				else if (stepType == 2 && crunchySteps.GetLength(0) > 0)
				{
					PlayRandomSound(crunchySteps);
				}
				//metal
				else if (stepType == 3 && metalSteps.GetLength(0) > 0)
				{
					PlayRandomSound(metalSteps);
				}
				//rubble
				else if (stepType == 4 && rubbleSteps.GetLength(0) > 0)
				{
					PlayRandomSound(rubbleSteps);
				}
            }
            if (rig != null)
            {
                Vector3 change = (transform.position - head.transform.position);
                //change.y = 0;
                //transform.position -= change;
                rig.transform.position += (change);
            }
        }
        else
        {
            if (thrust > 0)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
            if (thrust < 0)
            {
                transform.position -= transform.forward * Time.deltaTime * speed;
            }
        }

		if (Input.GetAxis("Horizontal") > 0) 
		{
			transform.Rotate(transform.up * 70.0f * Time.deltaTime);
		}
		if (Input.GetAxis("Horizontal") < 0) 
		{
			transform.Rotate(-transform.up * 70.0f * Time.deltaTime);
		}
	}


	public void SetStepType(int typeNum)
	{
		stepType = typeNum;
	}

	public void PlayRandomSound(AudioSource[] jukebox)
	{
		bool foundPlayingSound = false;
		for (int i = 0; i < jukebox.GetLength(0); i++)
		{
			if (jukebox[i].isPlaying)
			{
				foundPlayingSound = true;
				break;
			}
		}
		if (!foundPlayingSound)
		{
			int rand = (int)Mathf.Floor(Random.value * jukebox.GetLength(0));
			jukebox[rand].Play();
		}
	}
}
