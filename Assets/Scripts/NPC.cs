using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public enum NPCType {Cook,Guard};
    public NPCType NPC_Label;


    public static Action<int> ACT_DialoguePopup;
    public static Action ACT_OpenCathedralDoor;


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
                //ACT_DialoguePopup?.Invoke(1);
                //ACT_DialoguePopup?.Invoke(2);
                //collision.gameObject.GetComponent<PlayerInventory>().AddItem(1);

                if(collision.gameObject.GetComponent<PlayerDialogueTracker>().hasTalkedToGuardsAboutPie == true)
                {
                    if(collision.gameObject.GetComponent<PlayerDialogueTracker>().hasTalkedToCooksAboutPie == false)
                    {
                        //cooks tell where to get pie ingredients and gives key
                        ACT_DialoguePopup?.Invoke(130);
                        ACT_DialoguePopup?.Invoke(131);
                        ACT_DialoguePopup?.Invoke(132);
                        ACT_DialoguePopup?.Invoke(133);
                        ACT_DialoguePopup?.Invoke(134);
                        ACT_DialoguePopup?.Invoke(135);
                        ACT_DialoguePopup?.Invoke(136);
                        ACT_DialoguePopup?.Invoke(137);
                        collision.gameObject.GetComponent<PlayerDialogueTracker>().hasTalkedToCooksAboutPie = true;
                        collision.gameObject.GetComponent<PlayerInventory>().AddItem(1);
                    }
                    else if(collision.gameObject.GetComponent<PlayerDialogueTracker>().hasTalkedToCooksAboutPie == true)
                    {
                        if(collision.gameObject.GetComponent<PlayerInventory>().CheckForItem(5) == true){
                            //Cook pie
                            ACT_DialoguePopup?.Invoke(151);
                            ACT_DialoguePopup?.Invoke(152);
                            ACT_DialoguePopup?.Invoke(153);
                            ACT_DialoguePopup?.Invoke(154);
                            ACT_DialoguePopup?.Invoke(155);
                            ACT_DialoguePopup?.Invoke(156);
                            ACT_DialoguePopup?.Invoke(157);
                            ACT_DialoguePopup?.Invoke(158);
                            ACT_DialoguePopup?.Invoke(159);
                            ACT_DialoguePopup?.Invoke(160);
                            ACT_DialoguePopup?.Invoke(161);
                            ACT_DialoguePopup?.Invoke(162);
                            ACT_DialoguePopup?.Invoke(163);
                            collision.gameObject.GetComponent<PlayerInventory>().RemoveItem(5);
                            collision.gameObject.GetComponent<PlayerInventory>().AddItem(4);

                        }
                        else
                        {   
                            //text about needing ingredients
                            ACT_DialoguePopup?.Invoke(140);
                            ACT_DialoguePopup?.Invoke(141);
                            ACT_DialoguePopup?.Invoke(142);
                            ACT_DialoguePopup?.Invoke(143);
                            
                        } 
                    }
                    
                }
                else
                {
                    //princess first walks in hasn't talked to guards yet
                    ACT_DialoguePopup?.Invoke(90);
                    ACT_DialoguePopup?.Invoke(91);
                    ACT_DialoguePopup?.Invoke(92);
                }
            }
            else if (NPC_Label == NPCType.Guard) {
                if(collision.gameObject.GetComponent<PlayerDialogueTracker>().hasTalkedToGuardsAboutPie == false)
                {
                    //guards ask for pie
                    ACT_DialoguePopup?.Invoke(100);
                    ACT_DialoguePopup?.Invoke(101);
                    ACT_DialoguePopup?.Invoke(102);
                    ACT_DialoguePopup?.Invoke(103);
                    ACT_DialoguePopup?.Invoke(104);
                    ACT_DialoguePopup?.Invoke(105);
                    ACT_DialoguePopup?.Invoke(106);
                    ACT_DialoguePopup?.Invoke(107);
                    ACT_DialoguePopup?.Invoke(108);
                    ACT_DialoguePopup?.Invoke(109);
                    ACT_DialoguePopup?.Invoke(110);
                    ACT_DialoguePopup?.Invoke(111);
                    ACT_DialoguePopup?.Invoke(112);
                    ACT_DialoguePopup?.Invoke(113);
                    ACT_DialoguePopup?.Invoke(114);
                    ACT_DialoguePopup?.Invoke(115);
                    ACT_DialoguePopup?.Invoke(116);
                    ACT_DialoguePopup?.Invoke(117);
                    ACT_DialoguePopup?.Invoke(118);
                    ACT_DialoguePopup?.Invoke(119);
                    ACT_DialoguePopup?.Invoke(120);
                    ACT_DialoguePopup?.Invoke(121);
                    collision.gameObject.GetComponent<PlayerDialogueTracker>().hasTalkedToGuardsAboutPie = true;
                }
                else if(collision.gameObject.GetComponent<PlayerDialogueTracker>().hasTalkedToGuardsAboutPie == true)
                {
                    if(collision.gameObject.GetComponent<PlayerDialogueTracker>().hasGivenGuardsPie == false){
                        if(collision.gameObject.GetComponent<PlayerInventory>().CheckForItem(4) == true){
                            //allow to pass
                            collision.gameObject.GetComponent<PlayerInventory>().RemoveItem(4);
                            ACT_OpenCathedralDoor?.Invoke();
                            collision.gameObject.GetComponent<PlayerDialogueTracker>().hasGivenGuardsPie = true;
                            ACT_DialoguePopup?.Invoke(0);
                        }
                        else
                        {
                            //still waiting for pie
                            ACT_DialoguePopup?.Invoke(125);
                            ACT_DialoguePopup?.Invoke(126);
                            ACT_DialoguePopup?.Invoke(127);
                        }

                    }
                    if(collision.gameObject.GetComponent<PlayerDialogueTracker>().hasGivenGuardsPie == false)
                    {
                        //already given pie but haven't went in cathedral
                    }                 

                }


                //ACT_DialoguePopup?.Invoke(2);
            }
            

        }
    }
}
