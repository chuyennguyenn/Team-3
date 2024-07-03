using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableResult : MonoBehaviour
{
    public PotionSelector potionWindow;
    public GameObject placedItem;
    SpriteRenderer sr;
    SpriteRenderer psr;
    // Start is called before the first frame update
    void Start()
    {
        potionWindow = GetComponentInParent<PotionSelector>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() {
        if (potionWindow.selectedItem != null) {
            placedItem = potionWindow.selectedItem;
            psr = placedItem.GetComponent<SpriteRenderer>();
            Debug.Log(this.gameObject.name + " now contains " + potionWindow.selectedItem);
            potionWindow.selectedItem = null;
            sr.color = psr.color;
            //this.gameObject = potionWindow.selectedItem.gameObject;
            //potionWindow.selectedItem = null;
        }
        else {
            Debug.Log("There is no selected item to place here.");
        }
    }
}
