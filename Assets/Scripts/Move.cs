using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor_m = 0;
        float ver_m = 0;
        if(Input.GetKey(KeyCode.A))
        {
            hor_m = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            hor_m = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ver_m = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            ver_m = -1;
        }
        Vector3 velocity = (transform.forward * ver_m + transform.right * hor_m).normalized * speed;
        rb.AddForce(velocity);

        float hor_c = Input.GetAxis("Cam_Hor");
        transform.Rotate(new Vector3(0, hor_c, 0));

        
    }

    
}
