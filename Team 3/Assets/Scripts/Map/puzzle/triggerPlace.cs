using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerPlace : MonoBehaviour
{
    public bool reset = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            reset = true;
        }
    }

    private void OnTriggerExit2D()
    {
        reset = false;
    }
}
