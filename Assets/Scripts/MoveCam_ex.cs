using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField]
    enum Rot { X = 0, Y = 1, XandY = 2 }
    [SerializeField]
    Rot CurRot;
    [SerializeField]
    float sens_cam;
    float mos_x = 0, mos_y = 0;
    Quaternion org;
    // Start is called before the first frame update
    void Start()
    {
        org = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurRot == Rot.X)
        {
            mos_x += Input.GetAxis("Mouse X") * sens_cam;
            mos_x = Mathf.Clamp(mos_x % 360, -360, 360);
            Quaternion qX = Quaternion.AngleAxis(mos_x, Vector3.up);

            transform.localRotation = qX * org;
        }
        else if (CurRot == Rot.Y)
        {
            mos_y += Input.GetAxis("Mouse Y") * sens_cam;
            mos_y = Mathf.Clamp(mos_y % 360, -60, 90);
            Quaternion qY = Quaternion.AngleAxis(mos_y, -Vector3.right);

            transform.localRotation = qY * org;
        }
    }
}
