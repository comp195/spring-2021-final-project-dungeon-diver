using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : enemy
{
    //Aggro Variables
    public Transform target;        //leave empty, target will be selected in at start()
    public float chaseRadius;
    public float attackRadius;
    public Transform homePos;

    float amount;
    

    protected override void Start()
    {
        base.Start(); // call base class's start()

        target = GameObject.FindWithTag("Player").transform;        //set the player as the target
    }

    protected override void Update()
    {
        base.Update();  //call base class's update()
        CheckDistance();

    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius        //if player is inside chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)        //only chase until attackRadius
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);      //move towards target location

            CheckAnimation();
        }
    }
}
