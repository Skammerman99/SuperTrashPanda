using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour {

    public void SaveToFile(string path, SaveData data)
    //format the information of a saveData to binary and store it in PC as a file
    {
       
        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveDataFile = File.Create(path);
        //store the info need to save to a SaveData
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

}

[Serializable]
public class SaveData{
    
    public Vector3 position;
}
