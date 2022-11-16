using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Key : MonoBehaviour
{
    public bool consumeKey = false;
    public int unlockKey = 0;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            bool hasKey = collision.gameObject.GetComponent<CharacterInventory>().CheckForItem(unlockKey);
            if(hasKey)
            {
                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
