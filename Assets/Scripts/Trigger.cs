using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public List<TriggerEvent> Events;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate()
    {
        for (int i = 0; i < Events.Count; i++)
        {
            Events[i].Activate();
        }
    }

    public void Activate(bool state)
    {
        for (int i = 0; i < Events.Count; i++)
        {
            Events[i].Activate(state);
        }
    }

    public void Activate(int state)
    {
        for (int i = 0; i < Events.Count; i++)
        {
            Events[i].Activate(state);
        }
    }
}
