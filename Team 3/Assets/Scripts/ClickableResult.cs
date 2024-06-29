using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableResult : MonoBehaviour
{
    public PotionSelector potionWindow;
    public GameObject placedItem;
    // Start is called before the first frame update
    void Start()
    {
        potionWindow = GetComponentInParent<PotionSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() {
        if (potionWindow.selectedItem != null) {
            placedItem = potionWindow.selectedItem;
            Debug.Log(this.gameObject.name + " now contains " + potionWindow.selectedItem);
            //this.gameObject = potionWindow.selectedItem.gameObject;
            //potionWindow.selectedItem = null;
        }
        else {
            Debug.Log("There is no selected item to place here.");
        }
    }
}
