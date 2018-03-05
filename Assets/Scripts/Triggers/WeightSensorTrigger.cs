using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSensorTrigger : Trigger {

    //The number of objects counted as weighing on the sensor
    [SerializeField] private int weight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        weight++;
        Activate(weight);
    }

    private void OnTriggerExit(Collider other)
    {
        weight--;
        Activate(weight);
    }

}
