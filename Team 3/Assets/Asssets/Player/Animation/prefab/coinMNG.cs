using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class coinMNG : MonoBehaviour
{   
    public int coinCount;
    public TextMeshProUGUI coinText;
    public GameObject door;
    private bool doorDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "COIN: " + coinCount.ToString();
        
        if (coinCount == 6 && !doorDestroyed){
            doorDestroyed = true;
            Destroy(door);
        }
    }
}
