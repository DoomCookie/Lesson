using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    Transform otherTeleport;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            controller.enabled = false;
            other.gameObject.transform.position = otherTeleport.position + otherTeleport.transform.forward * 2;
            controller.enabled = true;
        }
        
    }





}
