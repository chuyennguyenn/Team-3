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

    public float moveSpeed = 1.0f;

    public DetectionZone entity;

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
        if (entity.zones.Count > 0)
        {
            Debug.Log("Hey");

            Vector2 direction  = (entity.zones[0].transform.position - transform.position).normalized;

            thisBody.AddForce(direction * moveSpeed * Time.deltaTime);
        }

        if (trig.GetComponent<triggerPlace>().reset == true)
        {
            this.transform.position = startPos;
        }

        if (looted == true)
        {
            moveSpeed = 0;
            Debug.Log("out");
            animator.SetBool("isOut", true);
            Destroy(gameObject, 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet1"))
        {
            Debug.Log("bullet1");
            moveSpeed = 0;
            thisBody.mass = 20;
            Destroy(other.gameObject);
        }
    }

    //IEnumerator destroyMe()
    //{
    //    yield return new WaitForSeconds(2);
    //    Destroy(gameObject);
    //}
}
