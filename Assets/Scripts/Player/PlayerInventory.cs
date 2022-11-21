using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    public ItemDatabase itemDb;
    public List<Item> InventoryList = new List<Item>();

    protected int Inventory_MaxSize = 4;
    
    public static Action<Item> ACT_UpdateInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddItem(int itemID){
        Item item = itemDb.Lookup(itemID);
        InventoryList.Add(item);
        Debug.Log("Added "+ item.itemName);
        ACT_UpdateInventory?.Invoke(item);
    }

    public void RemoveItem(int itemID)
    {
        foreach (Item item in InventoryList)
        {
            if(item.itemID == itemID){
                Debug.Log("Player has "+item.itemName);
                InventoryList.Remove(item);
                ACT_UpdateInventory?.Invoke(item);
                break;
            }
        }
    }

    public bool CheckForItem(int itemID)
    {
        foreach (Item item in InventoryList)
        {
            if(item.itemID == itemID){
                Debug.Log("Player has "+item.itemName);
                return true;
            }
        }
        Debug.Log("Player does not have "+itemID);
        return false;
    }
}
