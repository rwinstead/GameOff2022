using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePopup
{
    public int popupID;
    public string characterSpeaking;
    public string message;
    public bool portraitLeftSide; //Left or Right side
    public Sprite portraitSprite;


    public DialoguePopup(int popupID, string characterSpeaking, string message, string filename, bool portraitLeftSide = true)
    {
        this.popupID = popupID;
        this.characterSpeaking = characterSpeaking;
        this.message = message;
        this.portraitSprite = Resources.Load<Sprite>("Sprites/CharacterPortraits/" + filename);
        this.portraitLeftSide = portraitLeftSide;

        if(this.portraitSprite == null) {
            this.portraitSprite = Resources.Load<Sprite>("Sprites/Items/default");
        }
        
    }
}