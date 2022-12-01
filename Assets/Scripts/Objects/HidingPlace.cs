using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerSingleton.instance.SetTooltip("Press F to hide");
            InputHandler.instance.playerCanHide = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerSingleton.instance.tooltip.text == "") PlayerSingleton.instance.SetTooltip("Press F to hide");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerSingleton.instance.SetTooltip("");
            InputHandler.instance.playerCanHide = false;
        }
    }
}
