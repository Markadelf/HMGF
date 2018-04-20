using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var rend = GetComponent<Renderer>();
        rend.material.color = new Color(Random.value, Random.value, Random.value);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
