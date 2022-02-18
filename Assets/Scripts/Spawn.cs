using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject sphere;
    int count;
    //Score score;
    // Start is called before the first frame update
    private void Start()
    {
        //score = GetComponent<Score>(); ;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            GameObject sp = Instantiate(sphere);
            sp.transform.position = transform.position + transform.forward * 1;
            sp.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
            Delete_self ds = sp.GetComponent<Delete_self>();
            ds.count = count;
           //ds.score = score;

        }
    }
}
