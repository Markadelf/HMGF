using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultLock : Trigger {

    public List<GameObject> keys;

    public float Range;
    public int KeysNeeded;
    private int target;
    bool done;

    // Use this for initialization
    void Start()
    {
        if (KeysNeeded <= 0)
            KeysNeeded = keys.Count;
        target = keys.Count - KeysNeeded;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if((keys[i].transform.position - transform.position).sqrMagnitude < Range * Range)
            {
                Destroy(keys[i]);
                keys.RemoveAt(i);
                i--;
            }
        }
        if(keys.Count <= target && !done)
        {
            done = true;
            Activate(true);
        }
    }
}
