using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    //Singleton
    public static WaypointManager instance;

    ///<summary>
    ///The key is the string name of the room, value is the waypoints for that room
    ///</summary>
    public Dictionary<string, List<Transform>> waypoints = new Dictionary<string, List<Transform>>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
}
