using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform target;
    float maxScreenPoint = 0.2f;
    private Vector3 velocity;
    private float dampTime = 0.0f;

    // Start is called before the first frame update
    void Update()
    {
        
        Vector3 mousePos = Input.mousePosition * maxScreenPoint + new Vector3(Screen.width, Screen.height/1.2f, 0f) * ((1f - maxScreenPoint) * 0.5f);
        //Vector3 position = (target.position + GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) / 2f;
        Vector3 position = (target.position + GetComponent<Camera>().ScreenToWorldPoint(mousePos)) / 2f;
        Vector3 destination = new Vector3(position.x, position.y, -10);
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}
