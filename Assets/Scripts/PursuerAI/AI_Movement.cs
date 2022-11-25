using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    Vector3 target;
    NavMeshAgent agent;
    public Transform player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        SetTargetPosition();
        UpdatePosition();
    }

    void SetTargetPosition()
    {
        target = player.position;
        //For testing
        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void UpdatePosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
