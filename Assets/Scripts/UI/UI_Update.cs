using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Update : MonoBehaviour
{
    public CharacterInventory inventory;

    public GameObject InventorySlot1;
    public GameObject InventorySlot2;
    public GameObject InventorySlot3;
    public GameObject InventorySlot4;

    // Start is called before the first frame update
    void Start()
    {
        CharacterInventory.ACT_UpdateInventory += UpdateInventoryHUD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateInventoryHUD(Item item){
        print("Update HUD");
        int numItems = inventory.InventoryList.Count;
        print(numItems);
        if(numItems >= 1){InventorySlot1.GetComponent<Image>().sprite = inventory.InventoryList[0].itemIcon;}
        if(numItems >= 2){InventorySlot2.GetComponent<Image>().sprite = inventory.InventoryList[1].itemIcon;}
        if(numItems >= 3){InventorySlot3.GetComponent<Image>().sprite = inventory.InventoryList[2].itemIcon;}
        if(numItems >= 4){InventorySlot4.GetComponent<Image>().sprite = inventory.InventoryList[3].itemIcon;}
    }
}
