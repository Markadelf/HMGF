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
	public bool usingVRHeadset;

    public float speed = 5;
    //The camera
    public GameObject head;
    //The rig
    public GameObject rig;

    private SteamVR_TrackedObject leftControllerTrackedObject;
    private SteamVR_TrackedObject rightControllerTrackedObject;

    private Valve.VR.EVRButtonId thumbStick = Valve.VR.EVRButtonId.k_EButton_Axis2;
    private Valve.VR.EVRButtonId thumbPad = Valve.VR.EVRButtonId.k_EButton_Axis0;
    private Valve.VR.EVRButtonId trigger = Valve.VR.EVRButtonId.k_EButton_Axis1;

    private float swivelCounter = 0;
    private bool swivelRight = true;

    private SteamVR_Controller.Device LeftController
    {
        get {
            if(leftControllerTrackedObject == null)
            {
                var left = GameObject.Find("Controller (left)");
                if (left != null)
                {
                    leftControllerTrackedObject = left.GetComponent<SteamVR_TrackedObject>();
                }
            }
            return SteamVR_Controller.Input((int)leftControllerTrackedObject.index);
        }
    }
    private SteamVR_Controller.Device RightController
    {
        get
        {
            if (rightControllerTrackedObject == null)
            {
                var right = GameObject.Find("Controller (right)");
                if (right != null)
                {
                    rightControllerTrackedObject = right.GetComponent<SteamVR_TrackedObject>();
                }
            }
            return SteamVR_Controller.Input((int)rightControllerTrackedObject.index);
        }
    }

    // Use this for initialization
    void Start() 
	{
		stepType = 0;
    }

    // Update is called once per frame
    void Update ()
    {
		if (usingVRHeadset)
		{
			Swivel();

			if (head != null)
			{
				//Movement
				if (Mathf.Abs(LeftController.GetAxis(thumbStick).y) > .1f)
				{
					Vector3 forward = head.transform.forward;

					forward.y = 0;
					forward.Normalize();

					transform.position += forward * Time.deltaTime * speed * LeftController.GetAxis(thumbStick).y;
					PlaySounds();
				}

				if (Mathf.Abs(LeftController.GetAxis(thumbStick).x) > .1f)
				{ 
					Vector3 right = head.transform.right;

					right.y = 0;
					right.Normalize();

					transform.position += right * Time.deltaTime * speed * LeftController.GetAxis(thumbStick).x;
					PlaySounds();
				}

            
				//View Movement
				if (Mathf.Abs(RightController.GetAxis(thumbStick).x) > .1f)
				{
					transform.Rotate(transform.up, RightController.GetAxis(thumbStick).x * 70.0f * Time.deltaTime);
				}
            
				if (LeftController.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
				{
					//transform.Rotate(transform.up, -90);
					Swivel(-90);
					//Haptics no work!
					//LeftController.TriggerHapticPulse(2000, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
				}

				if (RightController.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
				{
					//transform.Rotate(transform.up, 90);
					Swivel(90);
					//Haptics no work!
					//RightController.TriggerHapticPulse(2000, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
				}

				if (rig != null)
				{
					Vector3 change = (transform.position - head.transform.position);
					change.y = 0;
					rig.transform.position += (change);
				}
			}
		}
		else
		{
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
	}


    private void Swivel()
    {
        if(swivelCounter > 0)
        {
            float rotationAmount = 360 * Time.deltaTime;

            swivelCounter -= rotationAmount;
            if (swivelCounter > 0)
            {
                transform.Rotate(transform.up,
                    swivelRight ? rotationAmount : -rotationAmount);
            }
            else
            {
                transform.Rotate(transform.up,
                    swivelRight ? rotationAmount + swivelCounter : -rotationAmount - swivelCounter);
            }
        }
    }
    private void Swivel(float degrees)
    {
        if(swivelCounter < 0)
        {
            swivelCounter = 0;
        }
        if(degrees > 0)
        {
            if (!swivelRight) swivelCounter = 0;
            swivelRight = true;
            swivelCounter += degrees;
        }
        else
        {
            if (swivelRight) swivelCounter = 0;
            swivelRight = false;
            swivelCounter -= degrees;
        }
    }

    public void SetStepType(int typeNum)
	{
		stepType = typeNum;
	}

    public void PlaySounds()
    {
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
