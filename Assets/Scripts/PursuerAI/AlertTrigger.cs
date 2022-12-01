using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertTrigger : MonoBehaviour
{
    public AI_Movement ai;
    public GameObject alertSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (ai.state == AI_Movement.State.Idle) return;
            if (InputHandler.instance.playerHiding) return;
            ai.SetState(AI_Movement.State.Sprinting);
            alertSprite.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (ai.state == AI_Movement.State.Idle) return;
            if (InputHandler.instance.playerHiding) return;
            ai.SetState(AI_Movement.State.Following);
            alertSprite.SetActive(false);
        }
    }
}
