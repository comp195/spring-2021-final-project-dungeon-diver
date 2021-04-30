using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addRoom : MonoBehaviour
{
    public roomTemplates templates;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();
        templates.rooms.Add(this.gameObject);
    }
}
