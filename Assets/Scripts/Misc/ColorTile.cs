using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A pressure plate sensor
/// </summary>
public class ColorTile : MonoBehaviour {

    //Allows specification of player only pressure triggers
    public bool PlayerOnly = false;
    public int color;
    public int x;
    public int y;
    public FloorTilePuzzle MyManager;

    //The number of objects counted as weighing on the sensor
    [SerializeField] private int weight;


	// Use this for initialization
	void Start () {
        MyManager.Connect(this);
	}
	
	// Update is called once per frame
	void Update () {
        MyManager.Connect(this);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!PlayerOnly || other.gameObject.tag == "Player")
        {
            weight++;
            MyManager.Move(this);
        }
    }

}
