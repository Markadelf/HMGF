using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Trigger {
    [SerializeField] private bool _state;
    private Animator _animator;
    private List<LeverSystem> _listeners;


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
        if (Input.GetKeyDown(KeyCode.R) && Vector3.Distance(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 2)
        {
            Flip();
        }
    }

    /// <summary>
    /// Flips the lever
    /// </summary>
    public void Flip()
    {
        _state = !_state;
        if (_state)
        {
            _animator.Play("Flip");
        }
        else
        {
            _animator.Play("Flip Back");
        }
        for (int i = 0; i < _listeners.Count; i++)
        {
            _listeners[i].Notify(this);
        }
        Activate(_state);
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

    
}
