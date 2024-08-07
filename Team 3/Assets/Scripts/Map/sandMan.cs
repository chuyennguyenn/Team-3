using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandMan : MonoBehaviour
{
    GameObject trig;
    Vector2 startPos;
    Rigidbody2D thisBody;

    void Start()
    {
        trig = GameObject.Find("triggerPlace");
        startPos = transform.position;
        thisBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        if (trig.GetComponent<triggerPlace>().reset == true)
        {
            this.transform.position = startPos;
        }
    }
}
