using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;

    public Item(int itemID, string itemName, string itemDescription, string filename)
    {
        this.itemID = itemID;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemIcon = Resources.Load<Sprite>("Sprites/Items/" + filename);

        this.itemIcon = Resources.Load<Sprite>("Sprites/Items/" + filename);

        if(this.itemIcon == null) {
            this.itemIcon = Resources.Load<Sprite>("Sprites/Items/default");
        }
        
    }
}