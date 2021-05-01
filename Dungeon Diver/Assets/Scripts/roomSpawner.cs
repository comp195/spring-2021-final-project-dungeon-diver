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
    private int roomArrLength = 0;
    public float waitTime = 4f;
    public int numRooms = 5;
    
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);      //this destroys the gameobject after the waitTime (4f). This might be the reason why 
                                            //the walls would disappear (when I tried to fix the rooms with doors leading to a wall)

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();
        roomArrLength = templates.leftRooms.Length;
        Invoke("Spawn", 0.1f);             // call the Spawn() function after 0.1 seconds
    }

    void Spawn()
    {
        if (spawned == false)             // make sure that the rooms are not already spawned in
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
            else if (openingDirection == 3)     // spawn room with left door
            {
                rand = Random.Range(0, roomArrLength);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)     // spawn room with left door
            {
                rand = Random.Range(0, roomArrLength);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spawnPoint"))         // so that rooms don't spawn on top of each other
        {
            if (other.GetComponent<roomSpawner>().spawned == false && spawned == false)
            {
                // spawn walls blocking off any openings
                Instantiate(templates.closeRooms, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if (other.GetComponent<roomSpawner>().spawned == false)
            {
                print("false");
            }
            
            spawned = true;
            //print("OUCH");
        }

        
    }
}
