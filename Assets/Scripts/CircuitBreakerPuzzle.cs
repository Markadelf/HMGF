using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreakerPuzzle : Grabable {

	public Camera myCamera;
	public AudioSource flipOnSound;
	public AudioSource flipOffSound;
	private float timer;
	private float timeTillReclick;
    float target;
    float current;
	[SerializeField] private GameObject[] allSwitchedSwitches;
	[SerializeField] private Material offMaterial;
	[SerializeField] private Material onMaterial;

    private bool flippedOff;

	// Use this for initialization
	void Start() 
	{
		timer = 0.0f;
		timeTillReclick = 0.3f;

        flippedOff = true;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Input.GetAxis("Interact") > 0 && timer > timeTillReclick)
		{
			Ray mouseToObj = myCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastInfo;
			bool didHit = Physics.Raycast(mouseToObj, out raycastInfo, 100.0f);
			if (didHit && raycastInfo.collider.gameObject == gameObject)
			{
				for (int i = 0; i < allSwitchedSwitches.GetLength(0); i++)
				{
					allSwitchedSwitches[i].GetComponent<StoreNumTicks>().numTicks++;
					if (allSwitchedSwitches[i].GetComponent<StoreNumTicks>().numTicks % 2 == 1)
					{
						allSwitchedSwitches[i].GetComponent<MeshRenderer>().material = onMaterial;
					}
					else
					{
						allSwitchedSwitches[i].GetComponent<MeshRenderer>().material = offMaterial;
					}
				}

				gameObject.GetComponent<StoreNumTicks>().numTicks++;

				if (gameObject.GetComponent<StoreNumTicks>().numTicks % 2 == 0)
				{
					flipOnSound.Play();
				}
				else
				{
					flipOffSound.Play();
				}

                if (flippedOff)
                {
                    transform.localRotation = Quaternion.Euler(20.0f, 0.0f, 90.0f);
                    flippedOff = false;
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
                    flippedOff = true;
                }
            }

			timer = 0.0f;
		}
        if(timer < timeTillReclick)
		    timer += Time.deltaTime;
        else
            timer = timeTillReclick;
        transform.localRotation = Quaternion.Euler(Mathf.Lerp(current, target, timer / timeTillReclick), 0.0f, 90.0f);
    }

    public override void Grab(GameObject grabber)
    {
        for (int i = 0; i < allSwitchedSwitches.GetLength(0); i++)
        {
            allSwitchedSwitches[i].GetComponent<StoreNumTicks>().numTicks++;
            if (allSwitchedSwitches[i].GetComponent<StoreNumTicks>().numTicks % 2 == 1)
            {
                allSwitchedSwitches[i].GetComponent<MeshRenderer>().material = onMaterial;
            }
            else
            {
                allSwitchedSwitches[i].GetComponent<MeshRenderer>().material = offMaterial;
            }
        }

        if (gameObject.GetComponent<StoreNumTicks>().numTicks % 2 == 0)
        {
            flipOnSound.Play();
        }
        else
        {
            flipOffSound.Play();
        }

        if (flippedOff)
        {
            target = 30;
            current = 0;
            flippedOff = false;
        }
        else
        {
            target = 0;
            current = 30;
            flippedOff = true;
        }

        timer = 0.0f;
    }

    public override void Release()
    {
    }
}
