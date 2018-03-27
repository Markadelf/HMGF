using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    Top,
    Bottom,
    Left,
    Right
}

/// <summary>
/// A puzzle manager for the crate puzzle in the storage room.
/// </summary>
public class CratePuzzleManager : MonoBehaviour {

    //Crate information
    public GameObject CratePrefab;
    private GameObject[,] crates;
    public GameObject CrateParent;
    public float dimension;

    //Board Interface Information




    //Game Information
    [SerializeField] private bool[,] state;


        
    // Use this for initialization
    void Start () {
        crates = new GameObject[5, 5];
        state = new bool[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                crates[i, j] = Instantiate(CratePrefab, CrateParent.transform);
                crates[i, j].transform.localPosition = new Vector3((i - 2) * dimension, 0, (j - 2) * dimension);

                state[i, j] = true;
            }
        }
        state[0, 2] = false;
        state[4, 2] = false;
        state[2, 0] = false;
        MoveCrates();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool Push(bool value, Side side, int pos)
    {
        bool ret = false;
        switch (side)
        {
            case Side.Top:
                ret = state[pos, 4];
                for (int i = 4; i > 0; i--)
                {
                    state[pos, i] = state[pos, i - 1];
                }
                state[pos, 0] = value;
                break;
            case Side.Bottom:
                ret = state[pos, 0];
                for (int i = 0; i < 4; i++)
                {
                    state[pos, i] = state[pos, i + 1];
                }
                state[pos, 4] = value;
                break;
            case Side.Left:
                ret = state[4, pos];
                for (int i = 4; i > 0; i--)
                {
                    state[i, pos] = state[i - 1, pos];
                }
                state[0, pos] = value;
                break;
            case Side.Right:
                ret = state[0, pos];
                for (int i = 0; i < 4; i++)
                {
                    state[i, pos] = state[i + 1, pos];
                }
                state[4, pos] = value;
                break;
            default:
                break;
        }
        MoveCrates();
        return ret;
    }

    public void MoveCrates()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                crates[i, j].SetActive(state[i, j]);
            }
        }
    }

}
