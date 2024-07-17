using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlePiece : MonoBehaviour
{
    // Start is called before the first frame update

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
             
        

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(thisBody.mass);
        if (other.gameObject.CompareTag("Player"))
        {
            thisBody.mass = 30;
            Debug.Log("dcm");
        }
        
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log(thisBody.mass);
        if (other.gameObject.CompareTag("Player"))
        {
            thisBody.mass = 10000;
            Debug.Log("dcm");
        }
    }
}
