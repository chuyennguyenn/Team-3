using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotionSelector : MonoBehaviour
{
    public GameObject firstItem;
    public GameObject secondItem;
    public GameObject selectedItem;
    public ClickableItem[] items;
    // Start is called before the first frame update
    void Start()
    {
        items = GetComponentsInChildren<ClickableItem>();
        //firstItem = GetComponentsInChildren<ClickableResult>();
        //print(items);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log(firstItem.name);
            Debug.Log(secondItem.name);
        }
    }

    public void testEventMessage() {
        Debug.Log("Event request received.");
    }
    public void itemSelected() {
        //selected.Invoke();
        selectedItem = this.gameObject;
        Debug.Log(selectedItem + " has been set.");
    }
    public GameObject itemSetter(GameObject currItem) {
        if (selectedItem != null) {
            firstItem = currItem;
            selectedItem = null;
            return firstItem;
        }
        return null;
    }
}