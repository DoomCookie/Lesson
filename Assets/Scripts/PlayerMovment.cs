using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float gravity;
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask groundMask;
    [SerializeField]
    float jumpHeight = 3f;
    [SerializeField]
    float groundDistance = 0.09f;
    
    bool isGrounded;

    Vector3 velocity;

    Vector3 oldMove;
    
    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        if(!isGrounded)
        {
            controller.Move(oldMove * speed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
            oldMove = move;
        }
        
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
