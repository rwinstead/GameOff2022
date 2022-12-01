using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Update : MonoBehaviour
{
    public PlayerInventory inventory;
    public DialogueDatabase dialogueDb;

    public GameObject InventorySlot1;
    public GameObject InventorySlot2;
    public GameObject InventorySlot3;
    public GameObject InventorySlot4;
    public GameObject InventorySlot5;
    public GameObject InventorySlot6;

    public GameObject DialogueBoxLeft;
    public GameObject DialogueBoxLeft_textbox;
    public GameObject DialogueBoxLeft_portrait;
    public GameObject DialogueBoxLeft_nameplate;
    
    public GameObject DialogueBoxRight;
    public GameObject DialogueBoxRight_textbox;
    public GameObject DialogueBoxRight_portrait;
    public GameObject DialogueBoxRight_nameplate;

    public GameObject DialogueBoxNoPortrait;
    public GameObject DialogueBoxNoPortrait_textbox;
    public GameObject DialogueBoxNoPortrait_nameplate;

    protected bool DialogueBoxActive = false;
    protected Queue<int> DialogueQueue = new Queue<int>();

    public static Action<bool> ACT_DialogueBoxPause;
    public static Action ACT_PlayDialogueBoxSFX;

    /// <summary>
    // This fires when a dialogue popup resolves to trigger things in the scene;
    /// </summary>
    public static Action<int> ACT_ResolvedDialogue;

    int prevDialogueID;

    // Start is called before the first frame update
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        NPC.ACT_DialoguePopup += DialoguePopupHandler;
        Door.ACT_DialoguePopup += DialoguePopupHandler;
        OpeningScene.ACT_DialoguePopup += DialoguePopupHandler;
        ItemPickup.ACT_DialoguePopup += DialoguePopupHandler;
        Interactables.ACT_DialoguePopup += DialoguePopupHandler;

        PlayerInventory.ACT_UpdateInventory += UpdateInventoryHUD;
        InputHandler.ACT_PlayerSpacebarPressed += DialogueInputHandler;
        EndingScene.ACT_DialoguePopup += DialoguePopupHandler;

        DialogueBoxLeft.SetActive(false);
        DialogueBoxRight.SetActive(false);
        InventorySlot1.SetActive(false);
        InventorySlot2.SetActive(false);
        InventorySlot3.SetActive(false);
        InventorySlot4.SetActive(false);
        InventorySlot5.SetActive(false);
        InventorySlot6.SetActive(false);
    }

    private void OnDestroy()
    {
        NPC.ACT_DialoguePopup -= DialoguePopupHandler;
        Door.ACT_DialoguePopup -= DialoguePopupHandler;
        OpeningScene.ACT_DialoguePopup -= DialoguePopupHandler;
        ItemPickup.ACT_DialoguePopup -= DialoguePopupHandler;
        Interactables.ACT_DialoguePopup -= DialoguePopupHandler;

        PlayerInventory.ACT_UpdateInventory -= UpdateInventoryHUD;
        InputHandler.ACT_PlayerSpacebarPressed -= DialogueInputHandler;
        EndingScene.ACT_DialoguePopup -= DialoguePopupHandler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateInventoryHUD(Item item){
        print("Update HUD");
        int numItems = inventory.InventoryList.Count;
        InventorySlot1.SetActive(false);
        InventorySlot2.SetActive(false);
        InventorySlot3.SetActive(false);
        InventorySlot4.SetActive(false);
        InventorySlot5.SetActive(false);
        InventorySlot6.SetActive(false);

        if(numItems >= 1)
        {
            InventorySlot1.SetActive(true);
            InventorySlot1.transform.Find("Image").GetComponent<Image>().sprite = inventory.InventoryList[0].itemIcon;
        }
        if(numItems >= 2)
        {
            InventorySlot2.SetActive(true);
            InventorySlot2.transform.Find("Image").GetComponent<Image>().sprite = inventory.InventoryList[1].itemIcon;
        }
        if(numItems >= 3)
        {
            InventorySlot3.SetActive(true);
            InventorySlot3.transform.Find("Image").GetComponent<Image>().sprite = inventory.InventoryList[2].itemIcon;
        }
        if(numItems >= 4)
        {
            InventorySlot4.SetActive(true);
            InventorySlot4.transform.Find("Image").GetComponent<Image>().sprite = inventory.InventoryList[3].itemIcon;
        }
        if(numItems >= 5)
        {
            InventorySlot5.SetActive(true);
            InventorySlot5.transform.Find("Image").GetComponent<Image>().sprite = inventory.InventoryList[4].itemIcon;
        }
        if(numItems >= 6)
        {
            InventorySlot6.SetActive(true);
            InventorySlot6.transform.Find("Image").GetComponent<Image>().sprite = inventory.InventoryList[5].itemIcon;
        }
    }

    void DialogueInputHandler(){
        if(DialogueBoxActive){
            DialogueAdvance();
        }
    }

    void DialoguePopupHandler(int popupID){
        DialogueQueue.Enqueue(popupID);
        if(DialogueBoxActive == false){
            DialogueAdvance();
        }
    }

    void DialoguePopupDisplay(int popupID){
        //print("Popup display ID: "+popupID);
        DialoguePopup popup = dialogueDb.Lookup(popupID);

        if(popup.popupType == DialoguePopup.pType.Left){
            DialogueBoxRight.SetActive(false);
            DialogueBoxNoPortrait.SetActive(false);
            DialogueBoxLeft_portrait.GetComponent<Image>().sprite = popup.portraitSprite;
            DialogueBoxLeft_nameplate.GetComponent<TextMeshProUGUI>().text = popup.characterSpeaking;
            DialogueBoxLeft_textbox.GetComponent<TextMeshProUGUI>().text = popup.message;
            DialogueBoxLeft.SetActive(true);
        }
        else if (popup.popupType == DialoguePopup.pType.Right){
            DialogueBoxLeft.SetActive(false);
            DialogueBoxNoPortrait.SetActive(false);
            DialogueBoxRight_portrait.GetComponent<Image>().sprite = popup.portraitSprite;
            DialogueBoxRight_nameplate.GetComponent<TextMeshProUGUI>().text = popup.characterSpeaking;
            DialogueBoxRight_textbox.GetComponent<TextMeshProUGUI>().text = popup.message;
            DialogueBoxRight.SetActive(true);
        }
        else {
            DialogueBoxLeft.SetActive(false);
            DialogueBoxRight.SetActive(false);
            DialogueBoxNoPortrait_nameplate.GetComponent<TextMeshProUGUI>().text = popup.characterSpeaking;
            DialogueBoxNoPortrait_textbox.GetComponent<TextMeshProUGUI>().text = popup.message;
            DialogueBoxNoPortrait.SetActive(true);
        }

        DialogueBoxActive = true;
        ACT_DialogueBoxPause?.Invoke(true);
        ACT_PlayDialogueBoxSFX?.Invoke();
    }

    void DialogueAdvance(){
        if (DialogueQueue.Count > 0){
            prevDialogueID = DialogueQueue.Peek() - 1;
            int popupID = DialogueQueue.Dequeue();
            DialoguePopupDisplay(popupID);
        }
        else{
            prevDialogueID++;
            DialogueBoxLeft.SetActive(false);
            DialogueBoxRight.SetActive(false);
            DialogueBoxNoPortrait.SetActive(false);
            DialogueBoxActive = false;
            ACT_DialogueBoxPause?.Invoke(false);
        }
        //print(prevDialogueID);
        ACT_ResolvedDialogue?.Invoke(prevDialogueID);

    }
}
