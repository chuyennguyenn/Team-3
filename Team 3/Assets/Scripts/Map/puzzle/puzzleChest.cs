using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleChest : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;

    bool unlocked = false;
    bool opened = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        unlocked = false;
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && unlocked == true && opened == true) {
            sandMan.looted = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") | collision.gameObject.CompareTag("puzzle"))
        {
            unlocked = true;
            animator.SetBool("triggered", true);
        }
           
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        unlocked = false;
        animator.SetBool("triggered", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("in");
            opened = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("out");
            opened = false;
        }
    }
}
