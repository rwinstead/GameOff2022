using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    public Animator playerAnim;
    public Animator marcoAnim;

    public static Action<int> ACT_DialoguePopup;

    public Transform Princess;
    public Transform PrincessMovesTo;
    public Transform PrincessMovesTo2;

    public Transform Marco;
    public Transform marcoMovesTo;

    public Camera endingCam;

    //Player that is used in actual game, not opening scene
    public GameObject mainPlayer;

    //Actual pursuer
    public GameObject mainMarco;

    List<int> dialogueResolved = new List<int>();

    public GameObject windowHole;

    private void Awake()
    {
        UI_Update.ACT_ResolvedDialogue += TriggerFromDialogue;
        mainPlayer.gameObject.SetActive(false);
        mainMarco.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        UI_Update.ACT_ResolvedDialogue -= TriggerFromDialogue;
    }

    private void Start()
    {

        EnterPrincess();
    }

    void TriggerFromDialogue(int id)
    {
        if (dialogueResolved.Contains(id)) return;

        dialogueResolved.Add(id);
        if(id == 177)
        {
            EnterMarco();
        }
        if(id == 185)
        {
            PrincessEscape();
        }
    }

    void EnterMarco()
    {
        Marco.gameObject.SetActive(true);
        marcoAnim.Play("MarcoWalkUp");
        StartCoroutine(LerpPosition(new Vector2(marcoMovesTo.position.x, marcoMovesTo.position.y), 2f, Marco, "Marco"));
        ACT_DialoguePopup?.Invoke(178);
        ACT_DialoguePopup?.Invoke(179);
        ACT_DialoguePopup?.Invoke(180);
        ACT_DialoguePopup?.Invoke(181);
        ACT_DialoguePopup?.Invoke(182);
        ACT_DialoguePopup?.Invoke(183);
        ACT_DialoguePopup?.Invoke(184);
        ACT_DialoguePopup?.Invoke(185);
    }

    void EnterPrincess()
    {
        playerAnim.Play("PrincessWalkUp");
        StartCoroutine(LerpPosition(new Vector2(PrincessMovesTo.position.x, PrincessMovesTo.position.y), 3f, Princess, "Princess1"));
    }

    void PrincessEscape()
    {
        playerAnim.Play("PrincessWalkLeft");
        StartCoroutine(LerpPosition(new Vector2(PrincessMovesTo2.position.x, PrincessMovesTo2.position.y), 3f, Princess, "Princess2"));
    }

    void CharacterReachedDestination(string character)
    {
        if (character == "Princess1")
        {
            ACT_DialoguePopup?.Invoke(177);
            playerAnim.Play("Idle");
        }
        if (character == "Marco")
        {
            marcoAnim.Play("MarcoIdle");
        }
        if (character == "Princess2")
        {
            windowHole.gameObject.SetActive(true);
            Princess.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(WaitToEnd());
        }
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

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("EndScreen");
    }

}
