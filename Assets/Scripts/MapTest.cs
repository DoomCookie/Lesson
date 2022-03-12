using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MapTest : MonoBehaviour
{
    [SerializeField]
    GameObject[] pixelsPrefabs;
    [SerializeField]
    int width, height, deeph;
    GameObject[,,] pixels;
    int count = 0;


    int[,,] map = new int[16,16,16];
    int[,] indexes =
    {
        {1, 5, 9 },
        {2, 5, 10 },
        {3, 0, 5 },
        {0, 14, 15 },
        {10, 10, 4 },
        {7, 9, 2 }

    };// x, y, z

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

        for(int i = 0; i < indexes.GetUpperBound(0) + 1; ++i)
        {
            map[indexes[i, 0], indexes[i, 1], indexes[i, 2]] = 1;
        }


        width = map.GetUpperBound(0) + 1;
        height = map.GetUpperBound(1) + 1;
        deeph = map.GetUpperBound(2) + 1;
        pixels = new GameObject[height, width, deeph];

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                for(int k = 0; k < deeph; ++k)
                {
                    int indx = map[i, j, k];
                    if (indx != 0)
                    {
                        pixels[i, j, k] = Instantiate(pixelsPrefabs[indx - 1]);
                        pixels[i, j, k].transform.SetParent(transform);
                        Vector3 pos = new Vector3(i * pixels[i, j, k].transform.localScale.x, j * pixels[i, j, k].transform.localScale.y, k * pixels[i, j, k].transform.localScale.z);
                        //Vector3 pos = Vector3.forward * i * pixels[i, j].transform.localScale.z + Vector3.right * j * pixels[i, j].transform.localScale.z
                        pixels[i, j, k].transform.localPosition = pos; //Vector3.forwads * i
                        count = (count + 1) % 7;
                    }
                }
                

            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
