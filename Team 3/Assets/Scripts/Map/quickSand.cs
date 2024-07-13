using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickSand : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        dummy player = other.GetComponent<dummy>();
        if (player != null)
        {
            player.MS = 5;
        }   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        dummy player = other.GetComponent<dummy>();
        if (player != null)
        {
            player.MS = 10;
        }
    }





}
