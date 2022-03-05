using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Generate : MonoBehaviour
{
    [SerializeField]
    GameObject[] pixelsPrefabs;
    [SerializeField]
    int width, height;
    GameObject[,] pixels;
    int count = 0;


    int[,] map =
    {
        {0, 0, 0, 0, 0 },
        {0, -1, 0, -1, 0 },
        {0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0 },
        {0, -1, 0, -1, 0 },
        {0, 0, 0, 0, 0 }

    };
    
    // Start is called before the first frame update
    void Start()
    {
        //StreamReader reader = new StreamReader("Assets\\Scripts\\TextFile1.txt");
        //string map_str = reader.ReadToEnd();
        
        //string[] lines = map_str.Split('\n');
        //for(int i = 0; i < lines.Length; ++i)
        //{
        //    string[] elements = lines[i].Split(' ');
        //    for(int j = 0; j < elements.Length; ++j)
        //    {
        //        map[i, j] = Convert.ToInt32(elements[j]);
        //    }
        //}




        height = map.GetUpperBound(0) + 1;
        width = map.GetUpperBound(1) + 1;
        pixels = new GameObject[height, width];
        
        for(int i = 0; i < height; ++i)
        {
            for(int j = 0; j < width; ++j)
            {
                int indx = map[i, j];
                if (indx != -1)
                {
                    pixels[i, j] = Instantiate(pixelsPrefabs[indx]);
                    pixels[i, j].transform.SetParent(transform);
                    Vector3 pos = new Vector3(j * pixels[i, j].transform.localScale.x, 0, i * pixels[i, j].transform.localScale.z);
                    //Vector3 pos = Vector3.forward * i * pixels[i, j].transform.localScale.z + Vector3.right * j * pixels[i, j].transform.localScale.z
                    pixels[i, j].transform.localPosition = pos; //Vector3.forwads * i
                    count = (count + 1) % 7;
                }
                
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
