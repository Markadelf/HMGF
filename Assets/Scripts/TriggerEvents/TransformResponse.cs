using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This reaction will delete the object it is on and spawn a prefab in its place
/// </summary>
public class TransformResponse : TriggerEvent {

    /// <summary>
    /// A prefab that this will change into
    /// </summary>
    public GameObject spawn;

    public override void Activate()
    {
        Instantiate(spawn, transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
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
