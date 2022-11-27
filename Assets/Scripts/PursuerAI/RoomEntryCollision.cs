using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntryCollision : MonoBehaviour
{
    /// <summary>
    /// List of waypoints that is passed to the AI upon entering the room that the collider is in.
    /// Each entry to a room should have a boxcollider2d with this script, with the public waypoints added in.
    /// </summary>
    public List<Transform> roomWaypoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Marco"))
        {
            collision.gameObject.GetComponent<AI_Movement>().waypoints = roomWaypoints;
        }
    }
}
