using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public enum NPCType {Cook,Guard};
    public NPCType NPC_Label;


    public static Action<int> ACT_DialoguePopup;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (NPC_Label == NPCType.Cook) {
                ACT_DialoguePopup?.Invoke(1);
                ACT_DialoguePopup?.Invoke(2);
                collision.gameObject.GetComponent<PlayerInventory>().AddItem(1);
            }
            else if (NPC_Label == NPCType.Guard) {
                ACT_DialoguePopup?.Invoke(3);
                //ACT_DialoguePopup?.Invoke(2);
            }
            

        }
    }
}
