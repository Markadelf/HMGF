using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this goes on anything that makes a persistent change to an object or the game state

public class UnlockDoor : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Open Door"))
        {
            SaveManager.saveLoadController.door1Unlocked = true;
        }
    }
}