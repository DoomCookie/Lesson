using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_self : MonoBehaviour
{
    Vector3 pos;
    public int index;
    [SerializeField]
    Material[] mr;
    public int count;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dist = transform.position - pos;
        if(dist.magnitude > 100)
        {
            Destroy(gameObject);
        }


        

    }

    private void OnCollisionEnter(Collision collision)
    {
        count = count % mr.Length;
        if(collision.gameObject.tag == "Target")
        {
            //(collision.gameObject);
            score.hit(100);
        }
        if(collision.gameObject.tag == "Target1")
        {
            collision.gameObject.GetComponent<MeshRenderer>().material = mr[count];
            score.hit(200);
        }
        if(collision.gameObject.tag == "Target2")
        {
            collision.gameObject.GetComponent<MeshRenderer>().material = mr[0];
            score.hit(300);
        }
        collision.gameObject.tag = "UnTarget";
        Destroy(gameObject);
    }

    private void OnCollisionExit(Collision other)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }


}
