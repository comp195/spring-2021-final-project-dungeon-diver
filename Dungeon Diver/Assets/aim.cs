using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
    public float moveSpeed = 8f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement2;
    Vector2 mousePos2;

    // Update is called once per frame
    // Update is not a good place to use for physics as framerate constantly changes
    // use fixed Update function (shown after the update function)

    private void Awake()
    {

    }

    void Update()
    {
        //input for movement

        //gives us a number for direction 
        movement2.x = Input.GetAxisRaw("Horizontal");    //(i.e. pressing right arrow returns 1)
        movement2.y = Input.GetAxisRaw("Vertical");

        mousePos2 = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    //by default this function is called 50 times a second
    private void FixedUpdate()
    {
        //actually doing movement

        //multiplying by time.fixeddeltatime allows for constant movespeed
        rb.MovePosition(rb.position + movement2 * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos2 - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;  
    }
}
