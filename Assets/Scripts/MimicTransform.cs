﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script that mimics another transform
/// </summary>
public class MimicTransform : MonoBehaviour
{

    //The transform to mimic
    public Transform track;

    //Options
    public bool move = true;
    public bool rotate = true;
    public bool scale = true;

    // Use this for initialization
    void Start () {
	}

    private void Awake()
    {
        if(move)
            transform.localPosition = track.localPosition;
        if(rotate)
            transform.localRotation = track.localRotation;
        if(scale)
            transform.localScale = track.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
            transform.localPosition = track.localPosition;
        if(rotate)
            transform.localRotation = track.localRotation;
        if(scale)
            transform.localScale = track.localScale;
    }


}
