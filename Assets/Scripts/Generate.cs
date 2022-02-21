using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    [SerializeField]
    GameObject[] pixelsPrefabs;
    [SerializeField]
    uint width, height;
    GameObject[,] pixels;

    
    // Start is called before the first frame update
    void Start()
    {
        pixels = new GameObject[width, height];
        
        for(int i = 0; i < height; ++i)
        {
            for(int j = 0; j < width; ++j)
            {
                pixels[i, j] = Instantiate(pixelsPrefabs[0]);
                pixels[i, j].transform.SetParent(transform);
                Vector3 pos = new Vector3(j * pixels[i, j].transform.localScale.x, 0, i * pixels[i, j].transform.localScale.z);
                //Vector3 pos = Vector3.forward * i * pixels[i, j].transform.localScale.z + Vector3.right * j * pixels[i, j].transform.localScale.z
                pixels[i, j].transform.localPosition = pos; //Vector3.forwads * i
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
