using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMangerScript : MonoBehaviour
{
    public GameObject GameOverUI;

    public PlayerHP PlayerHP;

    public PlayerCtrlV2 PlayerCtrlV2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver(){
        Debug.Log("GAME OVER");
        GameOverUI.SetActive(true);
    }
    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHP.HP = PlayerHP.maxHP;
        Debug.Log("RS");
        GameOverUI.SetActive(false);
        PlayerHP.animator.SetBool("isDead", false);
        PlayerCtrlV2.MS = 20;
    }
    public void menu(){
        SceneManager.LoadScene("TitleScreen");
        Debug.Log("MM");
    }
    public void quit(){
        Application.Quit();
        Debug.Log("Q");
    }
}
