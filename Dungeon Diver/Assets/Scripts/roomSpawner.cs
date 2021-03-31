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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (openingDirection == 1)
        {
            // bottom
        }
        else if (openingDirection == 2)
        {
            // top
        }
        else if (openingDirection == 3)
        {
            // left
        }
        else if (openingDirection == 4)
        {
            // right
        }
    }
}
