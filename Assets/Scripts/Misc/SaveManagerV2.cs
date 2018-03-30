using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagerV2 : MonoBehaviour
{
    // filepath
    public String saveFilePath;

    // Save
    public void Save()
    {
        SaveFileData sd = new SaveFileData();

        // get all objects tagged "door"
        GameObject[] doors = GameObject.FindGameObjectsWithTag("door");
        foreach (GameObject door in doors)
        {
            sd.doors.Add(door.name, JsonUtility.ToJson(door));
        }

        // get all objects tagged "keyItem"
        GameObject[] keyItems = GameObject.FindGameObjectsWithTag("keyItem");
        foreach (GameObject keyItem in keyItems)
        {
            sd.keyItems.Add(keyItem.name, JsonUtility.ToJson(keyItem));
        }

        // get object tagged "player"
        GameObject player = GameObject.FindGameObjectWithTag("player");
        sd.player.Add(player.name, JsonUtility.ToJson(player));

        // get all objects tagged "moveableObject"
        GameObject[] moveableObjects = GameObject.FindGameObjectsWithTag("moveableObject");
        foreach (GameObject moveableObject in moveableObjects)
        {
            sd.moveableObjects.Add(moveableObject.name, JsonUtility.ToJson(moveableObject));
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(saveFilePath, FileMode.OpenOrCreate);
        bf.Serialize(fs, sd);//write to file
        fs.Close();
    }

    // Load
    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(saveFilePath, FileMode.Open);
        SaveFileData sd = (SaveFileData)bf.Deserialize(fs);//read from file
        fs.Close();

        // load doors
        foreach (var doorName in sd.doors.Keys)
        {
            // transform
            GameObject data = JsonUtility.FromJson<GameObject>(sd.doors[doorName]);
            GameObject target = GameObject.Find(doorName);
            target.transform.position = data.transform.position;
            target.transform.rotation = data.transform.rotation;
            target.transform.localScale = data.transform.localScale;

            //lock
            //target.locked = data.locked
        }

        // load keyItems
        foreach (var keyItemName in sd.keyItems.Keys)
        {
            // transform
            GameObject data = JsonUtility.FromJson<GameObject>(sd.doors[keyItemName]);
            GameObject target = GameObject.Find(keyItemName);
            target.transform.position = data.transform.position;
            target.transform.rotation = data.transform.rotation;
            target.transform.localScale = data.transform.localScale;

            // anything else that needs to be loaded
        }

        // load player
        foreach (var player in sd.player.Keys)
        {
            // transform
            GameObject data = JsonUtility.FromJson<GameObject>(sd.doors[player]);
            GameObject target = GameObject.Find(player);
            target.transform.position = data.transform.position;
            target.transform.rotation = data.transform.rotation;
            target.transform.localScale = data.transform.localScale;

            // anything else that needs to be loaded
        }

        // load moveableObjects
        foreach (var moveableObjectName in sd.moveableObjects.Keys)
        {
            // transform
            GameObject data = JsonUtility.FromJson<GameObject>(sd.doors[moveableObjectName]);
            GameObject target = GameObject.Find(moveableObjectName);
            target.transform.position = data.transform.position;
            target.transform.rotation = data.transform.rotation;
            target.transform.localScale = data.transform.localScale;

            // anything else that needs to be loaded
        }
    }
}

// SaveFileData class
[Serializable]// serializable
class SaveFileData
{
    public Dictionary<String, String> doors;
    public Dictionary<String, String> keyItems;
    public Dictionary<String, String> player;
    public Dictionary<String, String> moveableObjects;

    public SaveFileData()
    {
        doors = new Dictionary<string, string>();
        keyItems = new Dictionary<string, string>();
        player = new Dictionary<string, string>();
        moveableObjects = new Dictionary<string, string>();
    }
}