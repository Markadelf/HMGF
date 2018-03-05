using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This destroys a game object when it is activated
public class DestroyResponse : TriggerEvent
{

    public GameObject target;

    public override void Activate()
    {
        if (target != null)
        {
            Destroy(target);
        }
    }

    public override void Activate(bool state)
    {
        if (state)
            Activate();
    }

    public override void Activate(int state)
    {
        if (state != 0)
            Activate();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
