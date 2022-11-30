using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpeningScene : MonoBehaviour
{
    public Animator playerAnim;
    public Animator marcoAnim;

    public static Action<int> ACT_DialoguePopup;

    public Transform Princess;
    public Transform PrincessMovesTo;

    public Transform Marco;
    public Transform marcoMovesTo;
    public GameObject southDoors;
    public GameObject rightDoors;

    public Camera openingCam;

    //Player that is used in actual game, not opening scene
    public GameObject mainPlayer;

    //Actual pursuer
    public GameObject mainMarco;

    private void Awake()
    {
        UI_Update.ACT_ResolvedDialogue += TriggerFromDialogue;
    }

    private void Start()
    {
        ACT_DialoguePopup?.Invoke(5);
        ACT_DialoguePopup?.Invoke(6);
        ACT_DialoguePopup?.Invoke(7);
        ACT_DialoguePopup?.Invoke(8);
        ACT_DialoguePopup?.Invoke(9);
        ACT_DialoguePopup?.Invoke(10);
        ACT_DialoguePopup?.Invoke(11);
    }

    void TriggerFromDialogue(int id)
    {
        if (id == 5)
        {
            southDoors.SetActive(false);
            EnterMarco();
        }
        if (id == 11)
        {
           rightDoors.SetActive(false);
            ExitPrincess();
        }
    }

    void EnterMarco()
    {
        Marco.gameObject.SetActive(true);
        marcoAnim.Play("MarcoWalkUp");
        StartCoroutine(LerpPosition(new Vector2(marcoMovesTo.position.x, marcoMovesTo.position.y), 4f, Marco, "Marco"));
    }

    void ExitPrincess()
    {
        playerAnim.Play("PrincessWalkRight");
        StartCoroutine(LerpPosition(new Vector2(PrincessMovesTo.position.x, PrincessMovesTo.position.y), 1.25f, Princess, "Princess"));
    }

    void CharacterReachedDestination(string character)
    {
        if(character == "Marco") marcoAnim.Play("MarcoIdle");
        if (character == "Princess")
        {
            StartGame();
        }
    }

    void StartGame()
    {
        Princess.gameObject.SetActive(false);
        openingCam.gameObject.SetActive(false);
        mainPlayer.gameObject.SetActive(true);
        mainMarco.gameObject.SetActive(true);
    }

    IEnumerator LerpPosition(Vector2 targetPosition, float duration, Transform character, string name)
    {
        float time = 0;
        Vector2 startPosition = character.position;
        while (time < duration)
        {
            character.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        character.position = targetPosition;
        CharacterReachedDestination(name);
    }

}
