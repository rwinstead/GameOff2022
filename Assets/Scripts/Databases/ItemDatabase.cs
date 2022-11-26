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
        itemDb.Add(new Item(1, "Green Key", "A Green Key", "greenkey"));
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
