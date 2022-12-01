using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecretDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Interactables.ACT_OpenSecretDoor += OpenSecretDoorHandler;       
    }

    void OpenSecretDoorHandler(){
        gameObject.SetActive(false);
    }
}
