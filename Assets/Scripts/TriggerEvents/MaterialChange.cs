using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : TriggerEvent {

    public List<Material> Mats;

    private Renderer _renderer;
    private int _pos;

    // Use this for initialization
    void Start () {
        _renderer = GetComponent<Renderer>();
        _pos = 0;
        _renderer.material = Mats[_pos];
    }

    // Update is called once per frame
    void Update () {
		
	}

    public override void Activate()
    {
        _pos = (_pos + 1) % Mats.Count;
        _renderer.material = Mats[_pos];
    }

    public override void Activate(bool state)
    {
        if (state)
        {
            _pos = 1;
        }
        else
        {
            _pos = 0;
        }
        _renderer.material = Mats[_pos];
    }

    public override void Activate(int state)
    {
        _pos = state;
        _renderer.material = Mats[_pos];
    }

}
