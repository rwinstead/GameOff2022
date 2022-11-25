using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWaypoints : MonoBehaviour
{
    public string roomName;
    public List<Transform> roomWaypoints = new List<Transform>();

    private void Start()
    {
        WaypointManager.instance.waypoints.Add(roomName, roomWaypoints);
    }
}
