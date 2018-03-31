using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A lever that can be flipped by external scripts
/// </summary>
public class Lever : TriggerEvent {
    [SerializeField] private bool _state;
    private Animator _animator;
    private List<LeverSystem> _listeners;
    public float Range = 5;

    private void Awake()
    {
        _listeners = new List<LeverSystem>();
    }

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < Range)
            Flip();
    }

    /// <summary>
    /// Flips the lever
    /// </summary>
    public void Flip()
    {
        _state = !_state;
        if (_animator != null)
        {
            if (_state)
            {
                _animator.Play("Flip");
            }
            else
            {
                _animator.Play("Flip Back");
            }
        }
        for (int i = 0; i < _listeners.Count; i++)
        {
            _listeners[i].Notify(this);
        }
    }


    public void Set(bool state)
    {
        if(state != _state)
        {
            Flip();
        }
    }

    public bool GetState()
    {
        return _state;
    }

    public void Listen(LeverSystem listener)
    {
        if (!_listeners.Contains(listener))
        {
            _listeners.Add(listener);
        }
    }

    public override void Activate()
    {
        Flip();
    }

    public override void Activate(bool state)
    {
        if (_state != state)
            Flip();
    }

    public override void Activate(int state)
    {
        Activate(state != 0);
    }
}
