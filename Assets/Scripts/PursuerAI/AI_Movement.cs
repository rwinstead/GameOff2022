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

    [Header("Movement Speeds")]
    public float walkingSpeed = 3f;
    public float runningSpeed = 4.5f;

    Vector3 target;
    NavMeshAgent agent;
    public Transform player;
    public List<Transform> startingWaypoints;
    int currentWaypoint = 0;

    Vector3 pausedPosition;

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

    public State state = State.Following;

    Animator anim;
    public string currentAnimState;

    private void Awake()
    {
        if (instance == null) instance = this;
        else DestroyImmediate(this);

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        waypoints = startingWaypoints;
        anim = GetComponent<Animator>();

        UI_Update.ACT_DialogueBoxPause += PauseMarco;
    }

    private void OnDestroy()
    {
        UI_Update.ACT_DialogueBoxPause -= PauseMarco;
    }

    void PauseMarco(bool pause)
    {
        if (pause) state = State.Idle;
        else state = State.Following;
        pausedPosition = transform.position;
    }

    private void Update()
    {
        SetTargetPosition();
        UpdatePosition();
        //For debugging
        //TODO: REMOVE  
        //if(Input.GetKeyDown(KeyCode.Space)) state = State.Wandering;

        if (agent.velocity.x == 0 && agent.velocity.y == 0) ChangeAnimationState("MarcoIdle");
        else if (agent.velocity.x > 0) ChangeAnimationState("MarcoWalkRight");
        else if (agent.velocity.x < 0) ChangeAnimationState("MarcoWalkLeft");
        else if (agent.velocity.y > 0) ChangeAnimationState("MarcoWalkUp");
        else if (agent.velocity.y < 0) ChangeAnimationState("MarcoWalkDown");
    }

    void SetTargetPosition()
    {
        switch(state)
        {
            case State.Following:
                target = player.position;
                agent.speed = walkingSpeed;
                break;
            case State.Sprinting:
                target = player.position;
                agent.speed = runningSpeed;
                break;
            case State.Wandering:
                target = waypoints[currentWaypoint].position;
                break;
            case State.Idle:
                transform.position = pausedPosition;
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
        if (newState == State.Sprinting) agent.speed = runningSpeed;
        if (newState == State.Following) agent.speed = walkingSpeed;
        if (newState == State.Wandering) agent.speed = walkingSpeed;
        if (newState == State.Idle) agent.speed = 0;

    }

    void ChangeAnimationState(string newState)
    {
        if (newState == currentAnimState) return;

        anim.Play(newState);
        currentAnimState = newState;
    }

}
