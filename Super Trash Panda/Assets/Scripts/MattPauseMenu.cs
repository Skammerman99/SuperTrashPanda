using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MattPauseMenu : MonoBehaviour
{
    private int index;
    public GameObject[] buttons;
    public Canvas MenuScreen;

    // Use this for initialization
    void Start()
    {
        //set selected button
        Select(1);
    }

    // Update is called once per frame
    void Update()
    {
        //when up is pressed
        if (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0)
        {
            if (index > 1) { Select(--index); }
        }
        //when down is pressed
        else if (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") < 0)
        {
            if (index < buttons.Length) { Select(++index); }
        }

        //when space is pressed
        else if (Input.GetButtonDown("Jump"))
        {
            switch (index)
            {
                case 1: //new game
                    {
                        TogglePauseMenu();
                        break;
                    }
                case 2: //load
                    {
                        ExitToTitle();
                        break;
                    }
                case 3://exit game
                    {
                        ExitGame();
                        break;
                    }
            }
        }

        else if (Input.GetButtonDown("Cancel")) {
            TogglePauseMenu();
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

    public void TogglePauseMenu()
    {
        // not the optimal way but for the sake of readability
        if (MenuScreen.GetComponentInChildren<Canvas>().enabled)
        {
            MenuScreen.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            MenuScreen.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

    private void ExitToTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

}

