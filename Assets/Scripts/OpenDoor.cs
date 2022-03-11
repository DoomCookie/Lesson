using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool isOpen;
    [SerializeField]
    Transform opened, closed;
    bool isMoving;
    int sign;

    
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        isMoving = false;
        sign = -1;
        print(Vector3.Distance(transform.position, opened.position));
    }

    // Update is called once per frame
    void Update()
    {
        sign = isOpen ? 1 : -1;

        //if (isOpen)
        //{
        //    sign = 1;

        //}
        //else
        //{
        //    sign = -1;
        //}
        if (isMoving)
        {
            transform.parent.Rotate(sign * Vector3.up * Time.deltaTime * 100);
        }

        if (isOpen && Vector3.Distance(transform.position, closed.position) < 0.005f)
        {
            isMoving = false;
            isOpen = false;
        }
        else if(!isOpen && Vector3.Distance(transform.position, opened.position) < 0.005f)
        {
            isMoving = false;
            isOpen = true;
        }
        
    }


    public void interactDoor()
    {
        isMoving = true;
        if (isOpen)
        {
            //transform.position = closed.position;
            //transform.rotation = closed.rotation;
            //isOpen = false;
        }
        else
        {
            //transform.position = opened.position;
            //transform.rotation = opened.rotation;
            //isOpen = true;
        }
    }


}
