using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public int controlIndex = 0;
    public Animator hand;
    bool isGrabObject;
    Grabable grabbedObject;
    private GrabAnimation last;

	void Start ()
    {
        isGrabObject = false;
        controlIndex = (int)GetComponentInParent<SteamVR_TrackedObject>().index;
    }
	
	
	void Update ()
    {
        //if(isGrabObject && ((!Input.GetButton("14") && !Input.GetButton("15"))) || Input.GetKey(KeyCode.Backspace))
        if (isGrabObject && ((Input.GetKey(KeyCode.Backspace) || !SteamVR_Controller.Input(controlIndex).GetHairTrigger()) || grabbedObject == null))
        {
            if(grabbedObject != null)
            grabbedObject.Release();
            isGrabObject = false;
            if (last == GrabAnimation.Grab)
                hand.Play("Relax");
        }
    }
    
    private void OnTriggerStay(Collider collision)
    {
        if (isGrabObject) return;
       
        //if(Input.GetButton("14") || Input.GetButton("15") || Input.GetKey(KeyCode.Space))
        if(Input.GetKey(KeyCode.Space) || SteamVR_Controller.Input(controlIndex).GetHairTrigger())
        {
            grabbedObject = collision.gameObject.GetComponent<Grabable>();

            if (grabbedObject == null || grabbedObject.grabbed) return;

            grabbedObject.Grab(gameObject);

            switch (grabbedObject.GrabType)
            {
                case GrabAnimation.Grab:
                    hand.Play("Grab");
                    break;
                case GrabAnimation.Door:
                    hand.Play("DoorOpen");
                    break;
                case GrabAnimation.Point:
                    hand.Play("ButtonPress");
                    break;
                default:
                    break;
            }
            last = grabbedObject.GrabType;
            isGrabObject = true;
        }
    }
}
