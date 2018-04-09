using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This object handles the floor tiles used in the puzzle.
/// </summary>
public class FloorTilePuzzle : TriggerEvent {


    public GameObject Prize;

    public ColorTile[,] Tiles = new ColorTile[5,5];
    public float dimension = 3.5f;
    int x;
    int y;

    public override void Activate()
    {
        this.enabled = false;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (Tiles[i, j] != null) Tiles[i, j].enabled = false;
            }
        }
    }

    public override void Activate(bool state)
    {
        this.enabled = state;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (Tiles[i, j] != null) Tiles[i, j].enabled = state;
            }
        }
    }

    public override void Activate(int state)
    {
        Activate(state != 0);
    }


    // Use this for initialization
    void Start () {
        x = (int)(Prize.transform.localPosition.x / dimension) + 2;
        y = (int)(Prize.transform.localPosition.z / dimension) + 2;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Move(ColorTile obj)
    {

        //Upon solution, kill the puzzle.
        if(obj == Tiles[x, y])
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Tiles[i, j] != null) Tiles[i, j].color = 0;
                }
            }
            return;
        }

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

        while(targets.Remove(null));
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
            if (dist > GetDistance(Tiles[x, y], obj))
            {
                x = furthest.x;
                y = furthest.y;
            }
        }
        Prize.GetComponent<EaseToLocation>().Move(Tiles[x, y].transform.position, 10);
    }

    //Simple dijkstra's for distance
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

    //Used to set up dependancies
    public void Connect(ColorTile obj)
    {
        obj.x = (int)(obj.transform.localPosition.x / dimension) + 2;
        obj.y = (int)(obj.transform.localPosition.z / dimension) + 2;
        Tiles[obj.x, obj.y] = obj;
    }
}
