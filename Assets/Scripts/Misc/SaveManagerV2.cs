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
        // get all saveable objects
        // run their save scripts and hold that data
        // make an instance of ObjectSaveData and put that data in their, paired with the name
        // serialize the ObjectSaveData to file
    }

    // Load
    public void Load()
    {
        // deserialize the save file into an ObjectSaveData instance
        // iterate through the trackedObjects
        // call Load() on each object, passing its save data (matching index in objectSaveData)
    }
}

// make a Saveable interface
public interface ISaveable
{
    // has an Awake or Start function // don't know which would be appropriate
    void Awake();
    
    // adds a reference to its name and type of save script in the SaveManager script
    // has a Save function
    string Save();// returns a serialized string

    // has a Load function
    void Load(string data);// takes an serialized string

}

// each different thing has a script that implements Saveable

// objectData class
[Serializable]// serializable
class ObjectSaveData
{
    // contains a list of objects and their serialized data (as strings)
    public List<String> trackedObjects;
    public List<String> objectSaveData;
}