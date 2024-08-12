using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMangerScript : MonoBehaviour
{
    public GameObject GameOverUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver(){
        GameOverUI.SetActive(true);
    }
    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("RS");
    }
    public void menu(){
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MM");
    }
    public void quit(){
        Application.Quit();
        Debug.Log("Q");
    }
}
