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
    public GameObject MarblePrefab;
    private GameObject[,] marbles;
    public Material Open;
    public Material Closed;
    private GameObject _extra;
    public GameObject Loose;
    public GameObject SensorPrefab;

    public int Period = 10;


    //Game Information
    [SerializeField] private bool[,] state;


        
    // Use this for initialization
    void Start () {
        Loose.GetComponent<Renderer>().material = Closed;
        crates = new GameObject[5, 5];
        state = new bool[5, 5];
        marbles = new GameObject[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                crates[i, j] = Instantiate(CratePrefab, CrateParent.transform);
                crates[i, j].transform.localPosition = new Vector3((i - 2) * dimension, 0, (j - 2) * dimension);
                marbles[i, j] = Instantiate(MarblePrefab, transform);
                marbles[i, j].transform.localPosition = new Vector3((i - 2) * dimension, 0, (j - 2) * dimension);
                state[i, j] = true;
            }
        }
        _extra = Instantiate(MarblePrefab, transform);
        _extra.GetComponent<Renderer>().material = Loose.GetComponent<Renderer>().material;
        _extra.SetActive(false);
        state[0, 2] = false;
        state[4, 2] = false;
        state[2, 0] = false;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                crates[i, j].SetActive(state[i, j]);
                marbles[i, j].GetComponent<Renderer>().material = state[i, j] ? Closed : Open;
            }
        }
        //Top
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                var sensor = Instantiate(SensorPrefab, transform);
                var pusher = sensor.GetComponent<PlacementPusher>();
                pusher.MyManager = this;
                pusher.side = (Side)i;
                pusher.index = j;
                pusher.Target = Loose;
                pusher.Range = .1f;
                switch (pusher.side)
                {
                    case Side.Top:
                        pusher.transform.localPosition = new Vector3((j - 2) * dimension, 0, (-3) * dimension);
                        break;
                    case Side.Bottom:
                        pusher.transform.localPosition = new Vector3((j - 2) * dimension, 0, (3) * dimension);
                        break;
                    case Side.Left:
                        pusher.transform.localPosition = new Vector3((-3) * dimension, 0, (j - 2) * dimension);
                        break;
                    case Side.Right:
                        pusher.transform.localPosition = new Vector3((3) * dimension, 0, (j - 2) * dimension);
                        break;
                    default:
                        break;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool Push(bool value, Side side, int pos)
    {
        bool ret = false;
        GameObject extra = null;
        _extra.transform.position = Loose.transform.position;
        Vector3 direction = new Vector3();
        switch (side)
        {
            case Side.Top:
                ret = state[pos, 4];
                extra = marbles[pos, 4];
                _extra.GetComponent<EaseToLocation>().Move(marbles[pos, 0].transform.position, Period);
                direction.z = 1;
                for (int i = 4; i > 0; i--)
                {
                    state[pos, i] = state[pos, i - 1];
                    marbles[pos, i - 1].GetComponent<EaseToLocation>().Move(marbles[pos, i].transform.position, Period);
                    marbles[pos, i] = marbles[pos, i - 1];
                }
                marbles[pos, 0] = _extra;
                state[pos, 0] = value;
                break;
            case Side.Bottom:
                ret = state[pos, 0];
                extra = marbles[pos, 0];
                _extra.GetComponent<EaseToLocation>().Move(marbles[pos, 4].transform.position, Period);
                direction.z = -1;
                for (int i = 0; i < 4; i++)
                {
                    state[pos, i] = state[pos, i + 1];
                    marbles[pos, i + 1].GetComponent<EaseToLocation>().Move(marbles[pos, i].transform.position, Period);
                    marbles[pos, i] = marbles[pos, i + 1];
                }
                marbles[pos, 4] = _extra;
                state[pos, 4] = value;
                break;
            case Side.Left:
                ret = state[4, pos];
                extra = marbles[4, pos];
                _extra.GetComponent<EaseToLocation>().Move(marbles[0, pos].transform.position, Period);
                direction.x = 1;
                for (int i = 4; i > 0; i--)
                {
                    state[i, pos] = state[i - 1, pos];
                    marbles[i - 1, pos].GetComponent<EaseToLocation>().Move(marbles[i, pos].transform.position, Period);
                    marbles[i, pos] = marbles[i - 1, pos];
                }
                marbles[0, pos] = _extra;
                state[0, pos] = value;
                break;
            case Side.Right:
                ret = state[0, pos];
                extra = marbles[0, pos];
                _extra.GetComponent<EaseToLocation>().Move(marbles[4, pos].transform.position, Period);
                direction.x = -1;
                for (int i = 0; i < 4; i++)
                {
                    state[i, pos] = state[i + 1, pos];
                    marbles[i + 1, pos].GetComponent<EaseToLocation>().Move(marbles[i, pos].transform.position, Period);
                    marbles[i, pos] = marbles[i + 1, pos];
                }
                marbles[4, pos] = _extra;
                state[4, pos] = value;
                break;
            default:
                break;
        }
        
        _extra.SetActive(true);
        _extra = extra;
        _extra.SetActive(false);
        Loose.transform.position = _extra.transform.position;
        Loose.GetComponent<EaseToLocation>().Move(Loose.transform.position + direction * dimension * transform.lossyScale.x, Period);
        Loose.GetComponent<Renderer>().material = ret ? Closed : Open;
        Loose.GetComponent<Grabable>().enabled = true;
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
