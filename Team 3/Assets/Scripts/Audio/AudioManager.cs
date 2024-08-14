using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    
    public AudioClip desert;
    public AudioClip dungeon;
    public AudioClip bossFight;

    public static bool desertMusic = false;
    public static bool dungeonMusic = false;
    public static bool bossFightMusic = false;


    private void Start()
    {
        musicSource.clip = desert;
        musicSource.Play(); 
    }
    

    private void Update()
    {

        if (desertMusic == true)
        {
            musicSource.clip = desert;
            musicSource.Play();
        }

        if (dungeonMusic == true)
        {
            musicSource.clip = dungeon;
            musicSource.Play();
        }

        if (bossFight == true)
        {
            musicSource.clip =bossFight;
            musicSource.Play();
        }
    }

}
