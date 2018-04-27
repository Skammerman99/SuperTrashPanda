using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour {
    private int index;
    public GameObject[] buttons;

	// Use this for initialization
	void Start () {
        //set initializ position depends on if there are save file exists
        Select(1);
	}
	
	// Update is called once per frame
	void Update () {
        //when up is pressed
        if (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0)
        {
            if (index > 1)
            {
                Select(--index);
            }
        }
        //when down is pressed
        else if (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") < 0)
        {
            if (index < buttons.Length)
            {
                Select(++index);
            }
        }
        //when space is pressed
        else if (Input.GetButtonDown("Jump"))
        {
            switch (index)
            {
                case 1: //new game
                    {
                        NewGame();
                        break;
                    }
                case 2: //load
                    {
                        LoadGameUI();
                        break;
                    }
                case 3://exit game
                    {
                        ExitGame();
                        break;
                    }
            }
        }
    }

    public void Select(int index)
    {
        this.index = index;
        //change the selected button's color
        for (int x = 1; x <= buttons.Length; ++x)
        {
            if (x == index)
            {
                buttons[x - 1].GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            }
            else
            {
                buttons[x - 1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }

    }
    //===================================================================
    //Funtion for Buttons
    //===================================================================

    private void NewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Town");
    }

    private void LoadGameUI()
    //Change to the Load Game UI
    {

    }

    private void ShowOptionUI()
     //Change to the Option UI
    {

    }

    private void ExitGame()
    {
        Application.Quit();
    }

}
