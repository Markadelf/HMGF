using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePuzzleManager : Trigger {


	public static int[] bottlesHit;
	public static int[] goal;

	// Use this for initialization
	void Start() 
	{
		bottlesHit = new int[4];
		goal = new int[4];
		goal[0] = 1;
		goal[1] = 3;
		goal[2] = 2;
		goal[3] = 4;
	}
	
	// Update is called once per frame
	void Update() 
	{
		int total = 0;
		for (int i = 0; i < bottlesHit.GetLength(0); i++)
		{
			if (bottlesHit[i] != goal[i])
			{
				break;
			}
			else
			{
				total++;
			}
		}
		if (total >= goal.GetLength(0))
		{
            Activate(true);
        }

    }

	public static void HitBottle(int bottleNum)
	{
		//print("Hit!");
		for (int i = 0; i < bottlesHit.GetLength(0); i++)
		{
			if (i != bottlesHit.GetLength(0) - 1)
			{
				bottlesHit[i] = bottlesHit[i + 1];
			}
			else
			{
				bottlesHit[i] = bottleNum;
			}
		}
	}
}
