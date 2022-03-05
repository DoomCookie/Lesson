using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet_pref, point;
    [SerializeField]
    float bullet_speed;
    [SerializeField]
    LayerMask target;
    [SerializeField]
    Transform camera;
    float count = 0;
    GameObject tmp;
    private void Start()
    {
        tmp = Instantiate(point);
        tmp.transform.localScale = Vector3.one * 0.2f;

    }

    void Update()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            tmp.transform.position = hit.point;
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 pos = transform.position;
            pos += transform.forward * 1f;
            GameObject bullet = Instantiate(bullet_pref);
            bullet.transform.position = pos;
            bullet.GetComponent<Delete_self>().index = 2;
            Rigidbody rb_b = bullet.GetComponent<Rigidbody>();
            bullet.GetComponent<Delete_self>().score = GetComponent<Score>();
            
            Vector3 vel = pos - transform.position;

            if (Physics.Raycast(ray, out hit))
            {
                vel = hit.point - pos;
            }

            vel = vel.normalized;
            rb_b.AddForce(vel * (bullet_speed), ForceMode.Impulse);
            count++;
        }
    }
}
