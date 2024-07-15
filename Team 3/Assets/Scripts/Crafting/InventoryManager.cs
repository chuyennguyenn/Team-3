using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from Night Run Studio's Inventory System Tutorial Series. Modified by Steven Mensah.
public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    bool menuActivated;
    public ItemSlot[] itemSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetButtonDown("Inventory")) {
        //     Debug.Log("Inventory key has been pressed.");
        // }

        if(Input.GetButtonDown("Inventory") && menuActivated) {
            //Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
            Debug.Log("Inventory open.");
        }

        else if(Input.GetButtonDown("Inventory") && !menuActivated) {
            //Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
            Debug.Log("Inventory close.");
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite) 
    { 
        // Debug.Log("itemName = " + itemName + "quantity = " + quantity + "itemSprite =" + itemSprite);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false) 
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite);
                return;
            }
        }
    }
}
