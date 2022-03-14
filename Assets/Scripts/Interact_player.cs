using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Interact_player : MonoBehaviour
{
    [SerializeField]
    Material mat;
    string[] tags = { "Target2", "Gun", "Door" };
    Material oldMat = null;
    GameObject lastFrameObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 2) && Array.Exists<string>(tags, element => element == hit.transform.tag))
        {
            if(!oldMat)
            {
                oldMat = hit.transform.GetComponent<MeshRenderer>().material;
            }
            hit.transform.GetComponent<MeshRenderer>().material = mat;
            if(Input.GetButtonDown("Interact"))
            {
                Interect inter = hit.transform.GetComponent<Interect>();
                if(hit.transform.tag == "Target2")
                {
                    inter.push();
                }
                else if (hit.transform.tag == "Gun")
                {
                    inter.pickup(gameObject.transform);
                }
                else if (hit.transform.tag == "Door")
                {
                    hit.transform.GetComponent<OpenDoorAnim>().InteractDoor();
                }
                
            }
            lastFrameObj = hit.transform.gameObject;
            
        }
        else if (oldMat)
        {
            lastFrameObj.GetComponent<MeshRenderer>().material = oldMat;
            oldMat = null;
        }
    }
}
