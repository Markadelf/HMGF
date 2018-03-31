using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LogicType
{
    And,
    Or,
    XOr,
    Count
}

//A logic gate based on a system of Levers
public class LeverSystem : Trigger {


    public List<Lever> Levers;
    public LogicType Logic;

    //Properties
    public bool Exclusive;


	// Use this for initialization
	void Start () {
        for (int i = 0; i < Levers.Count; i++)
        {
            Levers[i].Listen(this);
        }
	}


	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Updates the system when a lever flips
    /// </summary>
    /// <param name="sender"></param>
    public void Notify(Lever sender)
    {
        if (Exclusive && sender.GetState())
        {
            for (int i = 0; i < Levers.Count; i++)
            {
                if (Levers[i] != sender)
                    Levers[i].Set(false);
            }
        }
        int count = 0;
        for (int i = 0; i < Levers.Count; i++)
        {
            if (Levers[i].GetState())
                count++;
        }
        switch (Logic)
        {
            case LogicType.And:
                Activate(count == Levers.Count);
                break;
            case LogicType.Or:
                Activate(count > 0);
                break;
            case LogicType.Count:
                Activate(count);
                break; 
            case LogicType.XOr:
                Activate(count % 2);
                break;
            default:
                break;
        }
    }


}
