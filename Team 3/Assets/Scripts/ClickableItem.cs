using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    public PotionSelector potionWindow;
    SpriteRenderer sr;
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
        Debug.Log("I, " + this.gameObject.name + ", have been clicked.");
        potionWindow.selectedItem = this.gameObject;
    }
}
