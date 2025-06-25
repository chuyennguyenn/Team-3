using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burnableTree : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("in");
        }

        if (other.gameObject.CompareTag("bullet1"))
        {
            Debug.Log("bullet1");
            animator.SetTrigger("burning");
            Destroy(other.gameObject);
            Destroy(gameObject, 2);
           // animator.SetBool("locked", true);
            //animator.SetBool("burning", true);
        }
    }

}
