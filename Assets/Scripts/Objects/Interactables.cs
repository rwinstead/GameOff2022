using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{

    public enum InteractableItem {OpenSecretDoor,GiveWardrobeKey};
    public InteractableItem item;

    public static Action ACT_OpenSecretDoor;
    public static Action<int> ACT_DialoguePopup;

    private bool hasTriggered = false;

    //This script should be  used for any objects in the scene that can be examined,
    //and creates a dialogue event
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerSingleton.instance.SetTooltip("Press F to Interact");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                if(hasTriggered == false){
                    if(item == InteractableItem.OpenSecretDoor){
                        ACT_OpenSecretDoor?.Invoke();
                        ACT_DialoguePopup?.Invoke(21);
                        hasTriggered = true;
                        
                    }
                    if(item == InteractableItem.GiveWardrobeKey){
                        collision.gameObject.GetComponent<PlayerInventory>().AddItem(0);
                        ACT_DialoguePopup?.Invoke(22);
                        hasTriggered = true;                    
                    }
                }
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerSingleton.instance.SetTooltip("");
        }
    }
}

