using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadManager : Trigger {

    public static KeyPadManager active;
    private int _index = 0;
    private int[] _code = { 8, 7 };

	// Use this for initialization
	void Start () {
        active = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Notify(int val)
    {
        if(_code[_index] == val)
        {
            _index++;
            if(_index >= _code.Length)
            {
                Activate(true);
                _index = 0;
            }
        }
        else
        {
            _index = 0;
        }
    }
}
