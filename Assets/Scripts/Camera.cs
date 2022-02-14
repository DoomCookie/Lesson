using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    enum Rotation { X = 0, Y = 1}
    [SerializeField]
    Rotation rotation;
    [SerializeField]
    float sens;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotation == Rotation.Y)
        {
            float move_cam = Input.GetAxis("Mouse X") * sens;
            transform.Rotate(transform.up, move_cam);
        }
        else if(rotation == Rotation.X)
        {
            float move_cam = Input.GetAxis("Mouse Y") * sens;
            Vector3 direction_c = transform.localRotation.eulerAngles;
            transform.Rotate(-Vector3.right, move_cam);
            
            
        }
    }
}
