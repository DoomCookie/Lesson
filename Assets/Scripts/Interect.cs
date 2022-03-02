using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interect : MonoBehaviour
{
    [SerializeField]
    Transform cam;
    Material mat;
    MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    private void Update()
    {
        mesh.material = mat;
    }


    public void push()
    {
        Destroy(gameObject);
        Transform gun = cam.GetChild(0);
        if(gun)
        {
            
            Destroy(gun);
        }
        Vector3 coord_guns = gun.position;
        Shoot sh = gun.GetComponent<Shoot>();
        transform.SetParent(cam);
        transform.position = coord_guns;
        gameObject.AddComponent<Shoot>();


    }
}
