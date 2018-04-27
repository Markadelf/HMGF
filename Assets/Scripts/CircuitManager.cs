using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitManager : Trigger {

    [SerializeField] public StoreNumTicks[] theParts;
    [SerializeField] public bool[] isOdd;
    bool solved;

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        int numSuccesses = 0;
		for (int i = 0; i < theParts.GetLength(0); i++)
        {
            if (theParts[i].numTicks % 2 == 0 && !isOdd[i])
            {
                numSuccesses++;
            }
            else if (theParts[i].numTicks % 2 == 1 && isOdd[i])
            {
                numSuccesses++;
            }
        }
        if (numSuccesses >= theParts.GetLength(0) && !solved)
        {
            solved = true;
            Activate(true);
        }
	}
}
