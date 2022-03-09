using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject[] inventory;
    GameObject current;

    Ray ray;
    RaycastHit hit;

    GameObject prepareObject;
    GameObject lookAtBlock;

    // Start is called before the first frame update
    void Start()
    {
        
        if(inventory.Length != 0)
        {
            current = inventory[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkEvent();
        ray = new Ray(transform.position, transform.forward);
        Vector3 newBlockAt;
        if (Physics.Raycast(ray, out hit, 3))
        {
            if (hit.transform.gameObject != prepareObject)
            {
                lookAtBlock = hit.transform.gameObject;
                newBlockAt = hit.transform.position + hit.normal;
                if (!prepareObject)
                {

                    prepareObject = Instantiate(current);

                }
                prepareObject.transform.position = newBlockAt;
            }
                
        }
        else
        {
            Destroy(prepareObject);
        }
    }

    void checkEvent()
    {
        if (Input.GetButtonDown("Slot1"))
        {
            Debug.Log("Now 1");
            current = inventory[0];
            Destroy(prepareObject);
        }
        else if (Input.GetButtonDown("Slot2"))
        {
            Debug.Log("Now 2");
            current = inventory[1];
            Destroy(prepareObject);
        }
        else if (Input.GetButtonDown("Slot3"))
        {
            Debug.Log("Now 3");
            current = inventory[2];
            Destroy(prepareObject);
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            GameObject mapObject = prepareObject;
            prepareObject = null;
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if(lookAtBlock) Destroy(lookAtBlock);
        }
    }
}
