using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{



    float velocityx;
    float a = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        velocityx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float movez = Input.GetAxis("Vertical") * Time.deltaTime;
        float movex = Input.GetAxis("Horizontal") * 60 * Time.deltaTime;

        velocityx += a * movez;
        transform.position += transform.forward * velocityx;

        

        if (Mathf.Abs(velocityx) > 0.0f)
        {
            velocityx -= 0.05f * (Mathf.Sign(velocityx)) * Time.deltaTime;
            transform.Rotate(Vector3.up * movex);
        }

        if (Mathf.Abs(velocityx) > 0.1f)
        {
            velocityx = 0.1f * Mathf.Sign(velocityx);
        }

        if (Mathf.Abs(velocityx) < 0.0001f)
        {
            velocityx = 0;
        }



    }
}
