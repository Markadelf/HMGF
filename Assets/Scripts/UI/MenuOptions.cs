using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour {

	public Material selectedMat;
	public Material unselectedMat;

	//takes the player in the scene as a position reference
	public GameObject player;

	//takes the text contained in each option
	public string[] textFields;
	public GameObject[] backgrounds;

	//takes the scene's most dominant light; this light will be dimmed
	public Light sceneLighting;
	private float dimmerRatio;

	//the menu's resting position when it is not paused
	private Vector3 originalPosition;

	//how far away the menu will be when you pause
	private float distanceOffset;

	public static bool isPaused;
	private int timer;

	private int timeTillReclick;

	//current chosen option and the total number of options
	//highlightedOption at 0 means that the game is not paused
	private int highlightedOption;
	public int numOptions;

	// Use this for initialization
	void Start () {
		isPaused = false;
		dimmerRatio = 0.3f;
		timer = 0;
		highlightedOption = 0;
		numOptions = 3;
		timeTillReclick = 40;
		originalPosition = transform.position;
		distanceOffset = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//toggling pause on and off
		if (Input.GetAxis("Pause") > 0 && timer > timeTillReclick) 
		{
			
			isPaused = !isPaused;
			if (isPaused) 
			{
				print("Game paused!");
				highlightedOption = 1;

				//make the menu appear in front of the player
				transform.position = player.transform.position + distanceOffset*player.transform.forward;
				transform.rotation = player.transform.rotation;

				//dim the light
				sceneLighting.intensity *= dimmerRatio;
			} 
			else 
			{
				print("Game resumed!");
				highlightedOption = 0;

				//return the menu to its original position
				transform.position = originalPosition;

				//return the light's strength
				sceneLighting.intensity /= dimmerRatio;
			}
			timer = 0;
		}

		//moving the option down
		if (isPaused && Input.GetAxis("Vertical") < 0 && timer > timeTillReclick) 
		{
			
			if (highlightedOption < numOptions) 
			{
				highlightedOption++;
			} 
			else 
			{
				highlightedOption = 1;
			}
			print(highlightedOption);

			timer = 0;
		} 
		//moving the option up
		else if (isPaused && Input.GetAxis("Vertical") > 0 && timer > timeTillReclick) 
		{
			if (highlightedOption > 1) 
			{
				highlightedOption--;
			} 
			else 
			{
				highlightedOption = numOptions;
			}
			print(highlightedOption);

			timer = 0;
		}

		for (int i = 0; i < numOptions; i++) 
		{
			if (i == highlightedOption - 1) 
			{
				backgrounds[i].GetComponent<MeshRenderer>().material = selectedMat;
			} 
			else 
			{
				backgrounds[i].GetComponent<MeshRenderer>().material = unselectedMat;
			}
		}

		//selecting an option
		if (Input.GetAxis("Select") > 0 && timer > timeTillReclick) 
		{
			if (textFields[highlightedOption - 1] == "Save") 
			{				
				print("Pressed Save!");
			} 
			else if (textFields[highlightedOption - 1] == "Load") 
			{
				print("Pressed Load!");
			} 
			else if (textFields[highlightedOption - 1] == "Quit")
			{
				print("Pressed Quit!");
			}

			timer = 0;
		}

		if (isPaused) 
		{
			//make the menu appear in front of the player
			transform.position = player.transform.position + distanceOffset*player.transform.forward;
			transform.rotation = player.transform.rotation;
		}

		timer++;
	}
}
