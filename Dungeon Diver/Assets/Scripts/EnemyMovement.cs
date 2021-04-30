using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    public bool faceRight = true;
    private bool moving;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;


    public float dirNum;
    

    private void Start()
    {
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }

    void Update()
    {
        //input for movement
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rb.velocity = moveDirection;

            Vector3 perp = Vector3.Cross(transform.forward, moveDirection);
            float dir = Vector3.Dot(perp, transform.up);

            if (dir > 0.0f)
            {
                animator.SetBool("faceRight", true);
            }
            else if (dir < 0.0f)
            {
                animator.SetBool("faceRight", false);
            }

            animator.SetFloat("Speed", rb.velocity.sqrMagnitude);

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;

            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                
                moving = true;
                timeToMoveCounter = timeToMove;

                
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);  //Vector3(Random x, Random y, static z)
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {
            print("WALL");
        }
    }
}
