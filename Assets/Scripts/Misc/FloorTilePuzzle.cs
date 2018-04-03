﻿using System.Collections;
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
            dist = GetDistance(obj, furthest);
            for (int i = 1; i < targets.Count; i++)
            {
                int lDist = GetDistance(obj, targets[i]);
                if (dist < lDist)
                {
                    furthest = targets[i];
                    dist = lDist;
                }
            }
            if (dist > GetDistance(Tiles[x, y], obj) || ((x == 0 || x == 4) && (y == 0 || y == 4)))
            {
                x = furthest.x;
                y = furthest.y;
            }
        }
        Prize.GetComponent<EaseToLocation>().Move(Tiles[x, y].transform.position, 10);
    }

    public int GetDistance(ColorTile target, ColorTile other)
    {
        Queue<ColorTile> nodes = new Queue<ColorTile>();
        Queue<int> cost = new Queue<int>();
        List<ColorTile> dead = new List<ColorTile>();
        dead.Add(null);
        nodes.Enqueue(other);
        cost.Enqueue(0);

        while(nodes.Count > 0)
        {
            ColorTile node = nodes.Dequeue();
            int val = cost.Dequeue();
            if(node.x == target.x && node.y == target.y)
            {
                return val;
            }

            if (node.y < 4 && !dead.Contains(Tiles[node.x, node.y + 1]))
            {
                nodes.Enqueue(Tiles[node.x, node.y + 1]);
                cost.Enqueue(val + 1);
            }
            if (node.y > 0 && !dead.Contains(Tiles[node.x, node.y - 1]))
            {
                nodes.Enqueue(Tiles[node.x, node.y - 1]);
                cost.Enqueue(val + 1);
            }
            if (node.x < 4 && !dead.Contains(Tiles[node.x + 1, node.y]))
            {
                nodes.Enqueue(Tiles[node.x + 1, node.y]);
                cost.Enqueue(val + 1);
            }
            if (node.x > 0 && !dead.Contains(Tiles[node.x - 1, node.y]))
            {
                nodes.Enqueue(Tiles[node.x - 1, node.y]);
                cost.Enqueue(val + 1);
            }
            dead.Add(node);
        }


        return 0;
    }

    public void Connect(ColorTile obj)
    {
        obj.x = (int)(obj.transform.localPosition.x / dimension) + 2;
        obj.y = (int)(obj.transform.localPosition.z / dimension) + 2;
        Tiles[obj.x, obj.y] = obj;
    }
}
