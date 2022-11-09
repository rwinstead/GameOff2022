using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public GameObject SpawnPoint;
    private Rigidbody2D thisRb;
    
    private Vector2 playerInput_move;

    // Start is called before the first frame update
    void Start()
    {
        thisRb = GetComponent<Rigidbody2D>();
        InputHandler.ACT_PlayerMoveInput += PlayerControlHandler;
        thisRb.transform.position = SpawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move(playerInput_move.x,playerInput_move.y);
    }

    void Move(float moveX, float moveY)
    {
        Vector2 movement = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        thisRb.velocity = movement;
    }

    private void PlayerControlHandler(Vector2 playerInput)
    {
        playerInput_move = playerInput;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Reached Goal");
        }
    }

}