using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTexture : MonoBehaviour {
    public float Scale;
    public bool Wall;
    public float x, y;

	// Use this for initialization
	void Start () {
        var rend = GetComponent<Renderer>();
        if (Wall)
            rend.material.SetTextureScale("_MainTex", new Vector2(Scale * transform.localScale.x, Scale * transform.localScale.y));
        else
            rend.material.SetTextureScale("_MainTex", new Vector2(Scale * transform.localScale.x, Scale * transform.localScale.z));
        rend.material.SetTextureOffset("_MainTex", new Vector2(x, y));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
