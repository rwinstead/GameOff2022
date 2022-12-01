using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public int itemID;

    public static Action<int> ACT_DialoguePopup;

    void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerInventory>().AddItem(itemID);
                if(itemID == 5)
                {
                    ACT_DialoguePopup?.Invoke(20);
                }
                
                gameObject.SetActive(false);
            }
        }
}
