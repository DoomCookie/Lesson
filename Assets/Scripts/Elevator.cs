using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    float hight;
    public bool playerOnElevator;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerOnElevator && transform.position.y > 0)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        playerOnElevator = true;
    //    }
    //}


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && transform.position.y < hight)
        {
            playerOnElevator = true;
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnElevator = false;
        }
    }
}
