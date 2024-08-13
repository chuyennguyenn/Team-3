using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Tutorial from https://www.youtube.com/watch?v=-GWjA6dixV4.
public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene("TestPotionMenu");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
