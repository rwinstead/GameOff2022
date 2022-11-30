using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDatabase : MonoBehaviour
{

    public List<DialoguePopup> dialogueDb = new List<DialoguePopup>();

    private DialoguePopup defaultPopup; 

    // Start is called before the first frame update
    //public DialoguePopup(int popupID, string characterSpeaking, string message, Sprite portraitSprite, bool portraitLeftSide = False)
    void Awake()
    {
        defaultPopup = new DialoguePopup(0,"ERROR","Unable to retrieve dialogue message.  Check your message ID.","","None");

        dialogueDb.Add(new DialoguePopup(1,"COOK","Hello your highness! Are you hungry?\nI was about to make a tasty pie!","Cook1","Right"));
        dialogueDb.Add(new DialoguePopup(2,"COOK","Oh that creep is back?\nQuick, run to the other room! I'll distract him!","Cook1","Left"));
        dialogueDb.Add(new DialoguePopup(3,"GUARD","Oy! I'm a guard! Bring me pie!","Guard1","Left"));
        dialogueDb.Add(new DialoguePopup(4,"","This door is locked and requires a key","","None"));

        dialogueDb.Add(new DialoguePopup(5, "Morel", "What a lovely feast, Princess Plum.\nYou've really out done yourself this time.", "Morel", "Left"));
        dialogueDb.Add(new DialoguePopup(6, "Morel", "Now who is that strapping lad ente-", "Morel", "Left"));
        dialogueDb.Add(new DialoguePopup(7, "Marco", "M'lady! Letsa go-", "Marco", "Left"));
        dialogueDb.Add(new DialoguePopup(8, "Princess Plum", "Oh God, oh no.\nIt's that weird plumber who fixed my sink last week.", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(9, "Princess Plum", "He won't leave me alone, and he keeps muttering weird nonsense like 'Wahoo!'.", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(10, "Morel", "Quickly your highness, escape through the kitchens!\nI'll tell him he has the wrong castle.", "Morel", "Left"));
        dialogueDb.Add(new DialoguePopup(11, "Morel", "Not sure if he'll buy it for long, though. Now GO!", "Morel", "Left"));
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
