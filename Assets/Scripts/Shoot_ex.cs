using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_ex : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float speed_bull;
    public bool isShoot;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && isShoot)
        {
            Vector3 pos = transform.position;
            pos += transform.forward * 2f;
            GameObject bullet_copy = Instantiate(bullet);
            bullet_copy.transform.position = pos;
            bullet_copy.transform.localRotation = transform.rotation;
            Rigidbody rb = bullet_copy.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.forward * speed_bull, ForceMode.Impulse);
        }

    }
}
