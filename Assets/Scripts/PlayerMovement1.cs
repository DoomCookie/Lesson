using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    float speed;
    [SerializeField]
    float gravity;
    [SerializeField]
    Transform groundCheker;
    [SerializeField]
    float groundDistance;
    [SerializeField]
    float jumpHeight;

    Vector3 velocity;
    bool isGround;

    Vector3 oldMove;

    


    

    // Update is called once per frame
    void Update()
    {

        isGround = Physics.CheckSphere(groundCheker.position, groundDistance);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -9f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = (transform.forward * moveZ + transform.right * moveX) * speed * Time.deltaTime;


        //if(isGround)
        //{
        //    controller.Move(move);
        //    oldMove = move;
        //}
        //else
        //{
        //    controller.Move(oldMove);
        //}

        controller.Move(move);


        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
