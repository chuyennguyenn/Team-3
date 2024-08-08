using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandMan : MonoBehaviour
{
    GameObject trig;
    Vector2 startPos;
    Rigidbody2D thisBody;
    Animator animator;

    public static bool looted = false;

    void Start()
    {
        trig = GameObject.Find("triggerPlace");
        startPos = transform.position;
        thisBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (trig.GetComponent<triggerPlace>().reset == true)
        {
            this.transform.position = startPos;
        }

        if (looted == true)
        {
            Debug.Log("out");
            animator.SetBool("isOut", true);
            Destroy(gameObject, 2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    //IEnumerator destroyMe()
    //{
    //    yield return new WaitForSeconds(2);
    //    Destroy(gameObject);
    //}
}
