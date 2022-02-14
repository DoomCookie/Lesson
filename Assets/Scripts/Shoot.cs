using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet_pref;
    [SerializeField]
    float bullet_speed;
    float count = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 pos = transform.position;
            pos += transform.forward * 0.75f;
            GameObject bullet = Instantiate(bullet_pref);
            bullet.transform.position = pos;
            bullet.GetComponent<Delete_self>().index = 2;
            Rigidbody rb_b = bullet.GetComponent<Rigidbody>();
            Vector3 vel = pos - transform.position;
            vel = vel.normalized;
            rb_b.AddForce(vel * bullet_speed);
            count++;
        }
    }
}
