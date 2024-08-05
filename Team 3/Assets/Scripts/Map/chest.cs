using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    Animator animator;

    bool inThere = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        press();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            Debug.Log("in");
            inThere = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("out");
            inThere = false;
            animator.SetBool("isPress", false);
        }

    }

    private void press()
    {
        if (Input.GetKeyDown("e") && inThere == true)
        {
            Debug.Log("e");
            animator.SetBool("isPress", true);
        }
    }
}
