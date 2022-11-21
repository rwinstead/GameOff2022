using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject respawnPoint;

    public void Respawn(){
        print("Respawn Player");
        gameObject.transform.position = respawnPoint.transform.position;
    }
}
