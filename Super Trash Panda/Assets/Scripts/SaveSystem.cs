using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour {
    public string a;


    public void SaveToFile(string path)
    //format the information of a saveData to binary and store it in PC as a file
    {
       
        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveDataFile = File.Create(path);
        //store the info need to save to a SaveData
        SaveData data = new SaveData();
        //
        data.text = a;
        //
        bf.Serialize(saveDataFile, data);
        saveDataFile.Close();
    }

    public SaveData LoadFromFile(string path)
    //deserialize the info in a file to a SaveData object
    {
        //test if the saveData exists
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream saveDataFile = File.Open(path, FileMode.Open);
            //deserialize
            SaveData data = (SaveData)bf.Deserialize(saveDataFile);
            saveDataFile.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

    public void LoadGame(SaveData data)
    //load the game by the info of a SaveData object
    {
        //
        
        //
    }

}

[Serializable]
public class SaveData{
    //
    public string text;
    //
}
