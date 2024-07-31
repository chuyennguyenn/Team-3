using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossDoor : MonoBehaviour
{
    public int sceneBuildIndex;
    private static GameObject sampleInstance;

    void Awake()
    {
        if (sampleInstance != null)
            Destroy(sampleInstance);

        sampleInstance = gameObject;
        DontDestroyOnLoad(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("ok");
        if (other.tag == "Player")
        {
            print("switch");
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            
            GameObject spawnBoss = GameObject.Find("bossRoom");
            GameObject player = GameObject.Find("Player 1");
            Debug.Log(player.transform.position);
            player.transform.position = spawnBoss.transform.position;
            Debug.Log(spawnBoss.transform.position);
            Debug.Log(player.transform.position);



        }
    }
}
