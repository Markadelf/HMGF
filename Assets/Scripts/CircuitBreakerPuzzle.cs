using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreakerPuzzle : Grabable {

	public Camera myCamera;
	private float timer;
	private float timeTillReclick;
	[SerializeField] private GameObject[] allSwitchedSwitches;
	[SerializeField] private Material offMaterial;
	[SerializeField] private Material onMaterial;

	// Use this for initialization
	void Start() 
	{
		timer = 0.0f;
		timeTillReclick = 0.3f;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Input.GetAxis("Interact") > 0 && timer > timeTillReclick)
		{
			//print("Clicked!");
			Ray mouseToObj = myCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastInfo;
			bool didHit = Physics.Raycast(mouseToObj, out raycastInfo, 100.0f);
			print(raycastInfo.collider.gameObject);
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
			}

			timer = 0.0f;
		}

		timer += Time.deltaTime;
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

		timer = 0.0f;
    }

    public override void Release()
    {
    }
}
