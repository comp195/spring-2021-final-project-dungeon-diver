using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    //Enemy Components
    public Rigidbody2D rb;
    public Animator animator;
    
    //Enemy Variables
    public float moveSpeed;
    public bool faceRight = true;
    public bool chasing = false;

    //Enemy Movement
    public bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    //Enemy Idle Movement Direction
    public Vector3 moveDirection;
    private float dirNum;

    //Enemy Stats
    public int health;
    public string enemyName;
    public int baseAttack;

    protected virtual void Start()
    {
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }

    protected virtual void Update()
    {
        TakeDamage();





        //IdleMove();       //had to remove idle animation because I couldn't get it to work in
                            //tandem with the vector3.movetowards in the child class.
                            //IdleMove() uses rb.vector while the child class uses transform.position = new Vector3.moveTowards();
    }

    public void TakeDamage()
    {
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);         //maybe not call use code above instead?

            if (this.gameObject.name.Contains("Boss"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }

        }
    }

    public void IdleMove()
    {
        //non-aggro movement
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rb.velocity = moveDirection;
            
            CheckAnimation();

            //once timer runs out stop moving
            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
                animator.SetFloat("Speed", 0);
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
                //moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);  //random x and y direction, no change for z direction
                RandomDir();
            }
        }
    }

    public Vector3 RandomDir()
    {
        return moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);  //random x and y direction, no change for z direction
    }

    public void CheckAnimation()
    {
        //Animation Variables
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
    }
}
