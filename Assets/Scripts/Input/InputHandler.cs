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

    // Start is called before the first frame update
    void Start()
    {
        
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
            print("Spacebar pressed");
        }
        else {
            SpacebarTriggered = false;
        }
    }
}
