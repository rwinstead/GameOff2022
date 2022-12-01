using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    float scrollAmount = 0;
    Vector2 rawInput;

    public static Action<float> ACT_ZoomControl;
    public static Action<Vector2> ACT_PlayerMoveInput;
    public static Action ACT_PlayerSpacebarPressed;

    protected bool SpacebarTriggered = false;

    public static InputHandler instance;
    public bool playerCanHide = false;
    [HideInInspector]
    public bool playerHiding = false;

    public SpriteRenderer playerSprite;
    public GameObject FOV;
    public GameObject FOV2;
    public PlayerMovement pMovement;
    public CapsuleCollider2D pCol;

    private void Awake()
    {
        if (instance == null) instance = this;
        else DestroyImmediate(this);
    }

    // Update is called once per frame
    void Update()
    {
        scrollAmount = Input.GetAxis("Mouse ScrollWheel");
        if(scrollAmount != 0f)
        {
            ACT_ZoomControl?.Invoke(scrollAmount);
        }
        
        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");
        ACT_PlayerMoveInput?.Invoke(rawInput);

        if(Input.GetKeyDown(KeyCode.Space)){
            ACT_PlayerSpacebarPressed?.Invoke();
            SpacebarTriggered = true;
        }
        else {
            SpacebarTriggered = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && playerHiding)
        {
            playerSprite.enabled = true;
            FOV.gameObject.SetActive(true);
            FOV2.gameObject.SetActive(true);
            AI_Movement.instance.SetState(AI_Movement.State.Following);
            playerHiding = false;
            playerCanHide = true;
            pCol.enabled = true;
            pMovement.enabled = true;
            PlayerSingleton.instance.SetTooltip("");
        }

        else if (Input.GetKeyDown(KeyCode.F) && playerCanHide)
        {
            PlayerSingleton.instance.movement.thisRb.velocity = Vector2.zero;
            playerSprite.enabled = false;
            FOV.gameObject.SetActive(false);
            FOV2.gameObject.SetActive(false);
            playerHiding = false;
            pCol.enabled = false;
            pMovement.enabled = false;
            playerHiding = true;
            AI_Movement.instance.SetState(AI_Movement.State.Wandering);
            PlayerSingleton.instance.SetTooltip("Press F to exit");
        }

    }
}
