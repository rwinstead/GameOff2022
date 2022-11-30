using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{

    public List<Item> itemDb = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        itemDb.Add(new Item(0, "Blue Key", "A Blue Key", "bluekey"));
        itemDb.Add(new Item(1, "Pantry Key", "Key to the Pantry", "greenkey"));
        itemDb.Add(new Item(2, "Wardrobe Key", "Key to the Wardrobe", "bluekey"));
        itemDb.Add(new Item(3, "Armory Key", "Key to the Armory", "redkey"));
        itemDb.Add(new Item(4, "Pie Supplies", "Supplies to make a pie", "pie"));
    }

    public Item Lookup(int itemID){
        foreach (Item item in itemDb)
        {
            if(item.itemID == itemID){
                return item;
            }
        }
        return null;

    }
}
