using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is used only for the crate puzzle
public class PlacementPusher : MonoBehaviour {

    public GameObject Target;
    public float Range;
    public int index;
    public Side side;

    Vector3 _vel;
    int _time = -1;
    public int maxTime = 10;
    Quaternion _original;
    public CratePuzzleManager MyManager;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //If we've nabbed the object, slowly move it towards you
        if (_time != -1)
        {
            Target.transform.localPosition += _vel;
            Target.transform.localRotation = Quaternion.Slerp(Quaternion.identity, _original, ((float)_time) / maxTime);

            if (_time == 0)
            {
                MyManager.Push(Target.GetComponent<Renderer>().material.color == MyManager.Closed.color, side, index);
            }
            _time--;
        }
        else if (Target != null && (Target.transform.position - transform.position).sqrMagnitude < Range * Range)
        {
            var rigid = Target.GetComponent<Rigidbody>();
            if (rigid != null && !rigid.isKinematic)
            {
                Target.transform.parent = transform;
                _time = maxTime;
                _vel = -Target.transform.localPosition / _time;
                _original = Target.transform.localRotation;

                //Deactivate pesky things
                var grab = Target.GetComponent<Grabable>();
                if (grab != null) grab.enabled = false;
                if (rigid != null) { rigid.useGravity = false; rigid.isKinematic = true; }
            }
        }

    }
}
