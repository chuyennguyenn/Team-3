using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from Night Run Studio's Inventory System Tutorial Series. Modified by Steven Mensah.
public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player") 
        {
            inventoryManager.AddItem(itemName, quantity, sprite);
            Destroy(gameObject);
        }
    }
}
