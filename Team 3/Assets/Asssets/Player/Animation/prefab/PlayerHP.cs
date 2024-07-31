using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    public float HP;
    public float maxHP;
    public Image HPbar;
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        // maxHP = HP;  
    }

    // Update is called once per frame
    void Update()
    {
        if(HP < 0){
            HP = 0;
        }
        if(HP > maxHP){
            HP = maxHP;
        }
        HPbar.fillAmount = Mathf.Clamp(HP / maxHP, 0 , 1);

    }
}
