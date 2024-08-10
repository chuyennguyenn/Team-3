using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class levelLoader : MonoBehaviour
{
    public Animator transition;

    public int levelIndex;

    public float transitionTime = 1f;

    public static bool load = false;

    void Update()
    {
        
        LoadNextLevel();
        
    }

    public void LoadNextLevel()
    {   
        if (load == true)
        {
            StartCoroutine(LoadLevel(levelIndex));
            load = false;
        }

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);
        if (levelIndex == 1) { 
            if (LevelMove_Ref.trigger == true) //to dungeon 
            {
                GameObject player = GameObject.FindWithTag("Player");
                player.transform.position = new Vector2(82, 177);
                LevelMove_Ref.trigger = false;
            }

            if (bossRoomDoor.trigger == true) //map to dungeon via boss-room's door
            {
                GameObject player = GameObject.FindWithTag("Player");
                player.transform.position = new Vector2(85, 220);
                bossRoomDoor.trigger = false;
            }
        }

        if (levelIndex == 0)
        {
            if (dungeonDoor.trigger == true) //dungeon to map via main entrance
            {
                GameObject player = GameObject.FindWithTag("Player");
                player.transform.position = new Vector2(-280, 110);
                dungeonDoor.trigger = false;
            }

            if (bossDoor.trigger == true)   //to boss_room
            {
                GameObject player = GameObject.FindWithTag("Player");
                player.transform.position = new Vector2(-67, 205);
                bossDoor.trigger = false;
            }
        }

        SceneManager.LoadScene(levelIndex);
    }
}
