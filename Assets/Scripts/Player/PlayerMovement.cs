using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public GameObject SpawnPoint;
    private Rigidbody2D thisRb;
    
    private Vector2 playerInput_move;
    [SerializeField] FieldOfView FOV;
    [SerializeField] Camera mainCamera;

    protected bool DialogueBoxPause = false;

    // Start is called before the first frame update
    void Start()
    {
        thisRb = GetComponent<Rigidbody2D>();
        InputHandler.ACT_PlayerMoveInput += PlayerControlHandler;
        UI_Update.ACT_DialogueBoxPause += DialogueBoxPauseHandler;
        thisRb.transform.position = SpawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FOV.SetOrigin(transform.position);

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.nearClipPlane;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePos);
        Vector3 direction = new Vector3(
            worldPosition.x - transform.position.x,
         worldPosition.y - transform.position.y, worldPosition.z);


        FOV.SetAimDirection(direction);

    }

    void FixedUpdate()
    {
        Move(playerInput_move.x,playerInput_move.y);
    }

    void Move(float moveX, float moveY)
    {
        if(DialogueBoxPause == false){
            Vector2 movement = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
            thisRb.velocity = movement;
        }
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

    public void DialogueBoxPauseHandler(bool isActive){
        DialogueBoxPause = isActive;
    }

}