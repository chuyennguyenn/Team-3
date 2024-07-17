using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlePiece : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject trig;
    Vector2 startPos;

    void Start()
    {
        trig = GameObject.Find("triggerPlace");
        startPos = transform.position;
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
