﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int health = 5;


    public float moveSpeed;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;

    Vector2 movement;
    Vector2 mousePos;

    public bool faceRight = true;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    // Update is not a good place to use for physics as framerate constantly changes
    // use fixed Update function (shown after the update function)
    void Update()
    {
        //input for movement

        //gives us a number for direction 
        movement.x = Input.GetAxisRaw("Horizontal");    //(i.e. pressing right arrow returns 1)
        movement.y = Input.GetAxisRaw("Vertical");

        //left click = 0, right click = 1, middle click = 2
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attacking", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Attacking", false);
        }

        if (rb.position.x < mousePos.x)
            animator.SetBool("faceRight", true);
        else if (rb.position.x > mousePos.x)
            animator.SetBool("faceRight", false);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
       
    }

    //by default this function is called 50 times a second
    private void FixedUpdate()
    {
        //actually doing movement

        //multiplying by time.fixeddeltatime allows for constant movespeed
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        //makes the player sprite aim at the mouse
        //however, we don't want the sprite to actually aim.
        //rb.rotation = angle;  
    }
}
