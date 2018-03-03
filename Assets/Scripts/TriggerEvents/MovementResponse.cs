using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A movement response event that allows
/// </summary>
public class MovementResponse : TriggerEvent {

    //The location for state: false
    public Transform primaryLocation;
    //The location for state: true
    public Transform secondaryLocation;
    public float period;
    [SerializeField] private bool _state;
    private float _lerp;
    //This tracks whether or not the object still needs to move
    private bool _moving;

    //Options
    public bool move = true;
    public bool rotate = true;
    public bool scale = true;


    public override void Activate()
    {
        _state = !_state;
        _moving = true;
    }

    public override void Activate(bool state)
    {
        _state = state;
        _moving = true;
    }

    public override void Activate(int state)
    {
        _state = state != 0;
        _moving = true;
    }

    // Use this for initialization
    void Start () {
        period = 1;
	}

    private void Awake()
    {
        if(move)
            transform.localPosition = primaryLocation.localPosition;
        if(rotate)
            transform.localRotation = primaryLocation.localRotation;
        if(scale)
            transform.localScale = primaryLocation.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //If period is 0 just warp
        if (_moving)
        {
            if (period <= 0)
            {
                if (_state)
                {
                    if(move)
                        transform.localPosition = primaryLocation.localPosition;
                    if(rotate)
                        transform.localRotation = primaryLocation.localRotation;
                    if(scale)
                        transform.localScale = primaryLocation.localScale;
                }
                else
                {
                    if(move)
                        transform.localPosition = secondaryLocation.localPosition;
                    if(rotate)
                        transform.localRotation = secondaryLocation.localRotation;
                    if(scale)
                        transform.localScale = secondaryLocation.localScale;
                }
            }
            //Otherwise
            else
            {
                if (_state)
                    _lerp += Time.deltaTime / period;
                else
                    _lerp -= Time.deltaTime / period;
                if (_lerp < 0)
                {
                    _lerp = 0;
                    _moving = false;
                }
                else if (_lerp > 1)
                {
                    _lerp = 1;
                    _moving = false;
                }
                if (move)
                    transform.localPosition = Vector3.Lerp(primaryLocation.localPosition, secondaryLocation.localPosition, _lerp);
                if (rotate)
                    transform.localRotation = Quaternion.Lerp(primaryLocation.localRotation, secondaryLocation.localRotation, _lerp);
                if (scale)
                    transform.localScale = Vector3.Lerp(primaryLocation.localScale, secondaryLocation.localScale, _lerp);
            }
        }
    }


}
