using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dungeonDoor : MonoBehaviour
{
    public int sceneBuildIndex;

    public static bool trigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("ok");
        if (other.tag == "Player")
        {
            print("switch");
            //SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            //GameObject player = GameObject.FindWithTag("Player");
            //player.transform.position = new Vector2(-280, 110);
            levelLoader.load = true;
            trigger = true;
        }
    }
}
