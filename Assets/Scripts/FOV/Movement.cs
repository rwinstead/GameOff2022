using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private FieldOfView fieldOfView;
    public float moveSpeed = 1f;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    Vector3 worldPosition;

    Vector2 movement;


    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //All code below relates info to the field of view script
        if (fieldOfView != null) //FOV is not always present
        {
            fieldOfView.SetOrigin(transform.InverseTransformPoint(transform.position));

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 direction = new Vector3(
                worldPosition.x - transform.position.x,
             worldPosition.y - transform.position.y, worldPosition.z);


            fieldOfView.SetAimDirection(direction);
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}
