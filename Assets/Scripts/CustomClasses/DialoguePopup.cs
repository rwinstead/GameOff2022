using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePopup
{

    public enum pType {Left,Right,None};
    public int popupID;
    public string characterSpeaking;
    public string message;
    public pType popupType;
    public Sprite portraitSprite;


    public DialoguePopup(int popupID, string characterSpeaking, string message, string filename, string popuptype)
    {
        this.popupID = popupID;
        this.characterSpeaking = characterSpeaking;
        this.message = message;
        this.portraitSprite = Resources.Load<Sprite>("Sprites/CharacterPortraits/" + filename);
        
        if(popuptype == "Left"){
            this.popupType = pType.Left;
        }
        else if(popuptype == "Right"){
            this.popupType = pType.Right;
        }
        else if(popuptype == "None"){
            this.popupType = pType.None;
        }
        else {
            this.popupType = pType.None;
        }


        if(this.portraitSprite == null) {
            this.portraitSprite = Resources.Load<Sprite>("Sprites/Items/default");
        }
        
    }
}