using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("ok");
        if (other.tag == "Player")
        {
            print("switch");
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = new Vector2(193, -62);
        }
    }
}
