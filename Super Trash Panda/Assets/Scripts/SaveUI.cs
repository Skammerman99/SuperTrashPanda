using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveUI : MonoBehaviour {
    public GameObject[] slotArray;
    private int index = 1;
    private string filePathBase; // ..../Save/save   (need to add number.data after it)
    public SaveSystem saveSystem;

    private void Start()
    {
        //create the path
        filePathBase = Path.Combine(Application.dataPath, "Save");
        filePathBase = Path.Combine(filePathBase, "save");
        //show the information of savedate on the slots
        for (int x=1; x<=slotArray.Length; ++x)
        {
            SaveData data = saveSystem.LoadFromFile(filePathBase + x.ToString() +".data");
            ShowSaveInfo(slotArray[x-1], data);
        }
        Select(1);
    }

    private void Update()
    {
        //change the selected slot
        //when up is pressed
        if(Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical")>0)
        {
            if(index > 1)
            {
                Select(--index);
            }
        }
        //when down is pressed
        else if (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") < 0)
        {
            if (index < slotArray.Length)
            {
                Select(++index);
            }
        }
        //when space is pressed
        else if (Input.GetButtonDown("Jump"))
        {
            saveSystem.SaveToFile(filePathBase + index.ToString() + ".data");
            SaveData data = saveSystem.LoadFromFile(filePathBase + index.ToString() + ".data");
            ShowSaveInfo(slotArray[index - 1], data);
        }
    }

    private void Select(int index)
    //select another slot and change index
    {
        this.index = index;
        //change the color of slots to select the slot
        for(int x = 1; x<= slotArray.Length; ++x)
        {
            if(x == index)
            {
                slotArray[x-1].transform.Find("bg").gameObject.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            }
            else
            {
                slotArray[x-1].transform.Find("bg").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }

    private void ShowSaveInfo(GameObject slot, SaveData data)
    //show the info of savedata in that saveslot
    {
        if(data == null)//when this slot does not been used to contain savedata
        {
            slot.transform.Find("text").gameObject.GetComponent<Text>().text = "No Save Data";
        }
        else
        {
            slot.transform.Find("text").gameObject.GetComponent<Text>().text = data.text;
        }
    }
}
