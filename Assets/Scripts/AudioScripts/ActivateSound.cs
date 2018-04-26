using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSound : TriggerEvent {

    private AudioSource mySound;
    private float timer;
    private bool timeMoving;
    public float timeDelay;

    public override void Activate()
    {
        timeMoving = true;
    }

    public override void Activate(bool state)
    {
        if (state)
        {
            Activate();
        }
    }

    public override void Activate(int state)
    {
        Activate(state > 0);
    }

    // Use this for initialization
    void Start()
    {
        mySound = gameObject.GetComponent<AudioSource>();
        timer = -0.1f;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (timeMoving)
        {
            timer += Time.deltaTime;
        }

        if (timer >= timeDelay)
        {
            mySound.Play();
            timeMoving = false;
            timer = -0.1f;
        }
        
	}
}
