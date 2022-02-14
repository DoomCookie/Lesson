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
    float gravity = -9.81f;

    [SerializeField]
    Transform groundChecker;
    float distance = 0.2f;
    bool isGround;
    float jumpHeight = 3f;

    Vector3 velocity;

    Vector3 oldMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundChecker.position, distance);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -4f;
        }

        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 move = transform.forward * moveZ + transform.right * moveX;

        if (!isGround)
        {
            controller.Move(oldMove);
        }
        else
        {
            controller.Move(move);
            oldMove = move;
        }

        //controller.Move(move);

        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
