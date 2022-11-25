using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Marco"))
        {
            collision.gameObject.GetComponent<AI_Movement>().UpdateWaypoint();
        }
    }
}
