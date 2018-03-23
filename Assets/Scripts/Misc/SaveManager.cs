using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MAKE A GAME OBJECT AND PUT THIS SCRIPT ON IT (in every scene used)

public class SaveManager : MonoBehaviour {

    public static SaveManager saveLoadController;

    public bool door1Unlocked = false;
    public Transform appleTransform;
    private String saveFilePath = Application.persistentDataPath + "/playerInfo.dat";

    void Awake()
    {
        if (saveLoadController == null)
        {
            DontDestroyOnLoad(gameObject);
            saveLoadController = this;
        }
        else if (saveLoadController != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "doorOpen: " + door1Unlocked);
    }


    //this is your important section
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(saveFilePath, FileMode.OpenOrCreate); 

        PlayerData pd = new PlayerData();
        pd.door1Unlocked = door1Unlocked;
        //pd.appleTransform = appleTransform;

        bf.Serialize(fs, pd);//write to file
        fs.Close();
    }

    public void Load()
    {
        if(File.Exists(saveFilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(saveFilePath, FileMode.Open);

            PlayerData pd = (PlayerData)bf.Deserialize(fs);//read from file
            fs.Close();

            door1Unlocked = pd.door1Unlocked;
            //appleTransform = pd.appleTransform;
        }
        else
        {
            //whoops no file, do something or alert somebody
        }
    }
}

[Serializable]//we serialize this
class PlayerData
{
    public bool door1Unlocked;
    //public Transform appleTransform;
}