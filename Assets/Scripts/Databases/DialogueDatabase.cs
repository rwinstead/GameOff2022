using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDatabase : MonoBehaviour
{

    public List<DialoguePopup> dialogueDb = new List<DialoguePopup>();

    private DialoguePopup defaultPopup; 

    // Start is called before the first frame update
    //public DialoguePopup(int popupID, string characterSpeaking, string message, Sprite portraitSprite, bool portraitLeftSide = False)
    void Start()
    {
        defaultPopup = new DialoguePopup(0,"ERROR","Unable to retrieve dialogue message.  Check your message ID.","",true);

        dialogueDb.Add(new DialoguePopup(1,"COOK","Hello your highness! Are you hungry?\nI was about to make a tasty pie!","cook",false));
        dialogueDb.Add(new DialoguePopup(2,"COOK","Oh that creep is back?\nQuick, run to the other room! I'll distract him!","cook",true));
        dialogueDb.Add(new DialoguePopup(1,"COOK","Run to the other room! I'll distract him.","cook",true));
    }

    public DialoguePopup Lookup(int popupID){
        foreach (DialoguePopup popup in dialogueDb)
        {
            if(popup.popupID == popupID){
                return popup;
            }
        }
        return defaultPopup;

    }
}
