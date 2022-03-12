using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interect : MonoBehaviour
{
    [SerializeField]
    Material mat;
    MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
       
    }


    public void push()
    {
        Destroy(gameObject);
        


    }


    public void pickup(Transform cam)
    {
        Transform gun = cam.GetChild(0);
        if (gun)
        {

            Vector3 coord_guns = gun.localPosition;
            Quaternion rot = gun.localRotation;

            gun.SetParent(transform.parent);
            gun.localPosition = transform.localPosition;
            gun.localRotation = transform.localRotation;
            gun.GetComponent<Interect>().enabled = true;
            gun.GetComponent<Shoot>().enabled = false;


            transform.SetParent(cam);
            transform.localPosition = coord_guns;
            transform.localRotation = rot;
            
            GetComponent<Shoot>().enabled = true;
            GetComponent<Interect>().enabled = false;
        }

    }
}
