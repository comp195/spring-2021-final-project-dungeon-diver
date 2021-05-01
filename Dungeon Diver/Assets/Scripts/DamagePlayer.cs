using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().health -= 1;
            print("PlayerDmgEnemy!");

        }
        if (other.CompareTag("Player") && gameObject.name.Contains("Boss"))
        {
            other.GetComponent<PlayerMovement>().health -= 2;
            print("PlayerDmgBOss!");

        }
    }
}
