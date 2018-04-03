using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTilePuzzle : TriggerEvent {


    public GameObject Prize;

    public ColorTile[,] Tiles = new ColorTile[5,5];
    public float dimension = 3.5f;
    int x;
    int y;

    public override void Activate()
    {
        this.enabled = false;
    }

    public override void Activate(bool state)
    {
        this.enabled = state;
    }

    public override void Activate(int state)
    {
        this.enabled = state != 0;
    }


    // Use this for initialization
    void Start () {
        x = (int)(Prize.transform.localPosition.x / dimension) + 2;
        y = (int)(Prize.transform.localPosition.z / dimension) + 2;
        Tiles[2, 2] = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(ColorTile obj)
    {
        List<ColorTile> targets = new List<ColorTile>();
        int dist;
        ColorTile furthest;

        if (y < 4)
            targets.Add(Tiles[x, y + 1]);
        if(y > 0)
            targets.Add(Tiles[x, y - 1]);
        if (x < 4)
            targets.Add(Tiles[x + 1, y]);
        if (x > 0)
            targets.Add(Tiles[x - 1, y]);

        targets.Remove(null);
        for (int i = 0; i < targets.Count; i++)
        {
            if(obj.color == targets[i].color)
            {
                targets.RemoveAt(i);
                i--;
            }
        }
        if (targets.Count > 0)
        {
            furthest = targets[0];
            dist = Mathf.Abs(furthest.x - obj.x) + Mathf.Abs(furthest.y - obj.y);
            if (furthest.x == 2 && obj.x == 2 || furthest.y == 2 && obj.y == 2)
                dist += 2;
            for (int i = 1; i < targets.Count; i++)
            {
                int lDist = Mathf.Abs(targets[i].x - obj.x) + Mathf.Abs(targets[i].y - obj.y);
                if (targets[i].x == 2 && obj.x == 2 || targets[i].y == 2 && obj.y == 2)
                    lDist += 2;
                if (dist < lDist)
                {
                    furthest = targets[i];
                    dist = lDist;
                }
            }
            x = furthest.x;
            y = furthest.y;
        }
        Prize.GetComponent<EaseToLocation>().Move(Tiles[x, y].transform.position, 10);
    }

    public void Connect(ColorTile obj)
    {
        obj.x = (int)(obj.transform.localPosition.x / dimension) + 2;
        obj.y = (int)(obj.transform.localPosition.z / dimension) + 2;
        Tiles[obj.x, obj.y] = obj;
    }
}
