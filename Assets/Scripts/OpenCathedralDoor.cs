using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCathedralDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NPC.ACT_OpenCathedralDoor += OpenCathedralDoorHandler;       
    }

    private void OnDestroy()
    {
        NPC.ACT_OpenCathedralDoor -= OpenCathedralDoorHandler;
    }

    void OpenCathedralDoorHandler(){
        gameObject.SetActive(false);
    }
}
