using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAnim : MonoBehaviour
{

    bool isDown, isMoving;
    [SerializeField]
    Animator animator;
    Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        isDown = true;
        isMoving = false;

    }

    // Update is called once per frame
    void Update()
    {
        //if (oldPos == transform.position)
        //{
        //    isMoving = false;
        //}
        //oldPos = transform.position;

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        playerOnElevator = true;
    //    }
    //}


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isMoving)
        {
            isMoving = true;
            if(isDown)
            {
                animator.SetBool("isUp", true);
                animator.SetBool("isDown", false);
                isDown = false;
            }
            else
            {
                animator.SetBool("isUp", false);
                animator.SetBool("isDown", true);
                isDown = true;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        isMoving = false;
    }
}
