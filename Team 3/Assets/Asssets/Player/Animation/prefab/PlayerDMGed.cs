using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDMGed : MonoBehaviour
{
    public PlayerHP pHP;
    public float dmg;
    public float heal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // damaging player
        if(Input.GetKeyDown("g")){
            pHP.HP -= dmg;
        }
        //healing player
        if(Input.GetKeyDown("h")){
            pHP.HP += heal;
        }
    }
}
