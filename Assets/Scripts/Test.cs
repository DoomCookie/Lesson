using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Vector3 start_pos;
    [SerializeField]
    float speed;
    [SerializeField]
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(1, 1, 1));
        transform.position += velocity * speed;
        if(transform.position.x > 10)
        {
            transform.position = start_pos;
        }
    }
}
