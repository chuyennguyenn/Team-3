using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{

    public GameObject droppedItemPreFab;
    public List<Loot> lootList = new List<Loot>();

    Loot GetLoot()
    {
        int randomNum = Random.Range(1, 101);// 1-100
        List<Loot> possibleItems = new List<Loot>();

        foreach(Loot item in lootList)
        {
            if ( randomNum <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0,possibleItems.Count)];
            return droppedItem;
        }

        Debug.Log("no Loot Droppped");
        return null;
    }

    public void InsanLoot(Vector3 spawnPostion)
    {
        Loot droppedItem = GetLoot();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPreFab, spawnPostion, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;

            // floating or particles here!!
            //EXample
            // float dropForce = 300f
            // Vector2 dropDirection = new Vector2
        }
    }

}
