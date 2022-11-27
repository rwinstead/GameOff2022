using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour

{

    public bool requiresItem = false;
    public int itemRequired;

    public static Action<int> ACT_DialoguePopup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(requiresItem){
                bool hasKey = collision.gameObject.GetComponent<PlayerInventory>().CheckForItem(itemRequired);
                if(hasKey)
                {
                    gameObject.SetActive(false);
                }
                else{
                    ACT_DialoguePopup?.Invoke(4);
                }
            }
            else{
                gameObject.SetActive(false);
            }
            
            
        }
    }
}
