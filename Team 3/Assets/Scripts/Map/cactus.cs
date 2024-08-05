using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactus : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerCtrl>().health -= 1;
        Debug.Log(collision.gameObject.GetComponent<PlayerCtrl>().health);
    }
}
