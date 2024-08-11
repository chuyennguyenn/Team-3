using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class iron_chest : MonoBehaviour
{
    Animator animator;

    bool inThere = false;
    bool timer = false;

    public float remainTime;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        press();
        countDown();
        thraw();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("in");
            inThere = true;
        }

        if (other.gameObject.CompareTag("bullet2"))
        {
            Debug.Log("bullet2");
            Destroy(other.gameObject);
            animator.SetBool("locked", true);
            animator.SetBool("iced", true);
            timer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("out");
            inThere = false;
            animator.SetBool("pressed", false);
        }

    }

    private void press()
    {
        if (Input.GetKeyDown("e") && inThere == true)
        {
            Debug.Log("e");
            animator.SetBool("pressed", true);
        }
    }

    private void countDown()
    {
        if (timer == true)
        {
            remainTime -= Time.deltaTime;
            if (remainTime <= 0)
            {
                remainTime = 0;
                timer = false;
            }
        }
        
    }

    private void thraw()
    {
        if (remainTime == 0)
        {
            animator.SetBool("iced", false);
            animator.SetBool("locked", false);
        }
    }
}
