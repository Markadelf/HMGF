using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Like, Movement response but simpler, and not for use with the event system
public class EaseToLocation : MonoBehaviour {

    private Vector3 _target;
    private int _timeSpan = 0;
    private Vector3 _vel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(_timeSpan > 0)
        {
            transform.position += _vel;
            _timeSpan--;
        }
	}

    public void Move(Vector3 pos, int span)
    {
        _target = pos;
        _timeSpan = span;
        _vel = (_target - transform.position) / _timeSpan;
    }
}
