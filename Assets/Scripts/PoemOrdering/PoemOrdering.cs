using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemOrdering : Trigger {

	public static bool solved;
	public static int numPieces;
	public static float maxRange;
	public static float looseness;

	// Use this for initialization
	void Start() 
	{
		solved = false;
		numPieces = 3;
		maxRange = 5.0f;
		looseness = 0.5f;

		ListOfPoems.allPoemPieces = GameObject.FindGameObjectsWithTag("PoemPiece");

		//find out the right order and organize the array
		GameObject[] temp = new GameObject[ListOfPoems.allPoemPieces.GetLength(0)];

		for (int i = 0; i < temp.GetLength(0); i++)
		{
			temp[i] = ListOfPoems.allPoemPieces[i];
		}


		for (int i = 0; i < ListOfPoems.allPoemPieces.GetLength(0); i++)
		{
			for (int j = 0; j < temp.GetLength(0); j++)
			{
				if (temp[j].GetComponent<PoemPiece>().orderNum == i + 1)
				{
					ListOfPoems.allPoemPieces[i] = temp[j];
				}
			}
		}

		numPieces = ListOfPoems.allPoemPieces.GetLength(0);

		/*
		if (gameObject.GetComponent<PoemPiece>().orderNum != null)
		{
			ListOfPoems.allPoemPieces[gameObject.GetComponent<PoemPiece>().orderNum - 1] = this;
			print(ListOfPoems.allPoemPieces[orderNum - 1]);
		}
		*/

	}
	
	// Update is called once per frame
	void Update() 
	{
		//two requirements: must be vertically-aligned, and must be in order going down from the first
		solved = false;

		int alignCompares = 0;
		bool linearAlignment = false;
		bool inOrderX = false;
		bool inOrderZ = false;

		//order doesn't matter
		for (int i = 0; i < ListOfPoems.allPoemPieces.GetLength(0) - 1; i++)
		{
			float positionY = ListOfPoems.allPoemPieces[i].gameObject.transform.position.y;
			float comparePositionY = ListOfPoems.allPoemPieces[i + 1].gameObject.transform.position.y;
			if (Mathf.Abs(positionY - comparePositionY) < looseness)
			{
				alignCompares++;
			}
		}

		if (alignCompares >= numPieces - 1)
		{
			linearAlignment = true;
		}

		int xCompares = 0;
		int zCompares = 0;

		//if the first has a larger x than the last...
		if (ListOfPoems.allPoemPieces[0].gameObject.transform.position.x > ListOfPoems.allPoemPieces[numPieces - 1].gameObject.transform.position.x)
		{
			//all x values must be in order
			for (int i = 0; i < ListOfPoems.allPoemPieces.GetLength(0) - 1; i++)
			{
				float positionX = ListOfPoems.allPoemPieces[i].gameObject.transform.position.x;
				float comparePositionX = ListOfPoems.allPoemPieces[i + 1].gameObject.transform.position.x;
				if (positionX >= comparePositionX)
				{
					xCompares++;
				}
			}
		}
		//if it has a smaller x than the last...
		else
		{
			//all x values must be in order
			for (int i = 0; i < ListOfPoems.allPoemPieces.GetLength(0) - 1; i++)
			{
				float positionX = ListOfPoems.allPoemPieces[i].gameObject.transform.position.x;
				float comparePositionX = ListOfPoems.allPoemPieces[i + 1].gameObject.transform.position.x;
				if (positionX <= comparePositionX)
				{
					xCompares++;
				}
			}
		}

		if (xCompares >= numPieces - 1)
		{
			inOrderX = true;
		}


		//if the first has a larger z than the last...
		if (ListOfPoems.allPoemPieces[0].gameObject.transform.position.x > ListOfPoems.allPoemPieces[numPieces - 1].gameObject.transform.position.x)
		{
			//all z values must be in order
			for (int i = 0; i < ListOfPoems.allPoemPieces.GetLength(0) - 1; i++)
			{
				float positionZ = ListOfPoems.allPoemPieces[i].gameObject.transform.position.z;
				float comparePositionZ = ListOfPoems.allPoemPieces[i + 1].gameObject.transform.position.z;
				if (positionZ >= comparePositionZ)
				{
					zCompares++;
				}
			}
		}
		else
		{
			//all z values must be in order
			for (int i = 0; i < ListOfPoems.allPoemPieces.GetLength(0) - 1; i++)
			{
				float positionZ = ListOfPoems.allPoemPieces[i].gameObject.transform.position.z;
				float comparePositionZ = ListOfPoems.allPoemPieces[i + 1].gameObject.transform.position.z;
				if (positionZ <= comparePositionZ)
				{
					zCompares++;
				}
			}
		}

		if (zCompares >= numPieces - 1)
		{
			inOrderZ = true;
		}

		if (inOrderX && inOrderZ && linearAlignment)
		{
			solved = true;
            Activate(solved);
		}
	}
}
