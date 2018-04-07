using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyCharacterSoundEffects : MonoBehaviour {

	//class works closely with ChangeStepModes class

	//use 0 for basic, 1 for bathroom, 2 for crunchy, 3 for metal, and 4 for rubble
	[SerializeField] private int stepType;

	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}

	public void SetStepType(int typeNum)
	{
		stepType = typeNum;
	}
}
