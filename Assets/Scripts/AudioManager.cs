using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource backgroundTrack;
    public AudioSource SFXTrack;

    public AudioClip mainBGLoop;
    //public AudioClip bossBGLoop;

    public AudioClip dialoguePopupSFX;
    public AudioClip collectItemSFX;
    public AudioClip lockedDoorSFX;
    public AudioClip unlockDoorSFX;
    public AudioClip caughtByMarcoSFX;


    // Start is called before the first frame update
    void Start()
    {
        backgroundTrack.clip = mainBGLoop;
        backgroundTrack.Play();

        PlayerInventory.ACT_PlayCollectItemSFX += playCollectItemSFXHandler;
        Door.ACT_PlayLockedDoorSFX += playLockedDoorSFXHandler;
        Door.ACT_PlayUnlockDoorSFX += playUnlockDoorSFXHandler;
        UI_Update.ACT_PlayDialogueBoxSFX += playDialoguePopupSFXHandler;
        //Checkpoint.playCheckpointSFX += playCheckpointSFXHandler;

    }

    void playDialoguePopupSFXHandler()
    {
        //print("play sfx - popup");
        SFXTrack.PlayOneShot(dialoguePopupSFX, 0.7f);
    }
    void playCollectItemSFXHandler()
    {
        //print("play sfx - item");
        SFXTrack.PlayOneShot(collectItemSFX, 0.7f);
    }
    void playLockedDoorSFXHandler()
    {
        //print("play sfx - locked door");
        SFXTrack.PlayOneShot(lockedDoorSFX, 1f);
    }
    void playUnlockDoorSFXHandler()
    {
        //print("play sfx - unlock door");
        SFXTrack.PlayOneShot(unlockDoorSFX, 1f);
    }
    void playCaughtByMarcoSFXHandler()
    {
        //print("play sfx - caught marco");
        SFXTrack.PlayOneShot(caughtByMarcoSFX, 0.7f);
    }

    /* Example code robbed from Runemancer
    void playCheckpointSFXHandler()
    {
        SFXTrack.PlayOneShot(checkpointSFX, 0.45f);
    }

    void playBossMusicHandler()
    {
        backgroundTrack.clip = bossBGLoop;
        backgroundTrack.volume = 0.3f;
        backgroundTrack.Play();
    }
    */
}
