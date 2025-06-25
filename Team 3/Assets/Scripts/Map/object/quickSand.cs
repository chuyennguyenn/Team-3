using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickSand : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl player = other.GetComponent<PlayerCtrl>();
        if (player != null)
        {
            player.MS = 5;
        }   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerCtrl player = other.GetComponent<PlayerCtrl>();
        if (player != null)
        {
            player.MS = 10;
        }
    }





}
