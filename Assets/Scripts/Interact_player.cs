﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_player : MonoBehaviour
{
    [SerializeField]
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 2) && hit.transform.tag == "Target2")
        {
            hit.transform.GetComponent<MeshRenderer>().material = mat;
            if(Input.GetButton("Interact"))
            {
                Interect inter = hit.transform.GetComponent<Interect>();
                inter.push();
            }
            
        }
    }
}