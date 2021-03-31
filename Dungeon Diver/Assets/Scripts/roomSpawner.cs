using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawner : MonoBehaviour
{
    public int openingDirection;
    /*
    1 = bottom
    2 = top
    3 = left
    4 = right
    */

    private roomTemplates templates;
    private int rand;
    private int roomArrLength = 8;

    public bool spawned = false;
    public int numRooms = 5;
    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();
        Invoke("Spawn", 0.2f);             // call the Spawn() function after 0.1 seconds
    }

    void Spawn()
    {
        if (spawned == false && index != numRooms)             // make sure that the rooms are not already spawned in
        {
            if (openingDirection == 1)          // spawn room with bottom door
            {
                rand = Random.Range(0, roomArrLength);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)     // spawn room with top door
            {
                rand = Random.Range(0, roomArrLength);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            //else if (openingDirection == 3)     // spawn room with left door
            //{
            //    rand = Random.Range(0, roomArrLength);
            //    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            //}
            //else if (openingDirection == 4)     // spawn room with right door
            //{
            //    rand = Random.Range(0, roomArrLength);
            //    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            //}
            spawned = true;
            index++;
            print(index);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         
        if (collision.CompareTag("spawnPoint"))         // so that rooms don't spawn on top of each other
        {
            if (collision.GetComponent<roomSpawner>().spawned == false && spawned == false)
            {
                // spawn walls blocking off any openings
                Instantiate(templates.closeRooms, transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }
}
