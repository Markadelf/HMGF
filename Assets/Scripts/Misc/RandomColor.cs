using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {

    public List<Material> mats;

	// Use this for initialization
	void Start () {
        var rend = GetComponent<Renderer>();
        rend.material = mats[Random.Range(0, mats.Count)];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
