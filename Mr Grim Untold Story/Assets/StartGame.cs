using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject UI;


    public void GameMenu()
    {
        MainMenu.SetActive(false);
        UI.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
