using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    /// <summary>
    /// Use this singleton to change the state machine of the AI
    /// </summary>
    public static AI_Movement instance;

    Vector3 target;
    NavMeshAgent agent;
    public Transform player;
    public List<Transform> startingWaypoints;
    int currentWaypoint = 0;

    //Each room should have waypoints already created in them. This way, when player hides,
    //we can reach out and get the waypoints for the current room, throw them into this array
    //then iterate through.
    [HideInInspector]
    public List<Transform> waypoints = new List<Transform>();

    //Each state results in different behavior
    //Following is a slow walk towards player
    //Sprinting means player is in range and Marco is trying to catch them
    //Wandering means player is hiding and Marco goes elsewhere
    public enum State
    {
        Following,
        Sprinting,
        Wandering,
        Idle
    }

    State state = State.Following;

    private void Awake()
    {
        if (instance == null) instance = this;
        else DestroyImmediate(this);

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        waypoints = startingWaypoints;
    }

    private void Update()
    {
        SetTargetPosition();
        UpdatePosition();
        //For debugging
        //TODO: REMOVE  
        if(Input.GetKeyDown(KeyCode.Space)) state = State.Wandering;
    }

    void SetTargetPosition()
    {
        switch(state)
        {
            case State.Following:
                target = player.position;
                break;
            case State.Sprinting:
                target = player.position;
                agent.speed = 5f;
                break;
            case State.Wandering:
                target = waypoints[currentWaypoint].position;
                break;
            case State.Idle:
                target = transform.position;
                break;
        }
    }

    public void UpdateWaypoint()
    {
        int length = waypoints.Count;
        currentWaypoint++;
        if (currentWaypoint >= length) currentWaypoint = 0;
    }

    void UpdatePosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

    public void SetState(State newState)
    {
        state = newState;
    }
}
