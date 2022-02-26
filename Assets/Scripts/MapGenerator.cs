using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] tiles;
    GameObject[,] map;
    

    int width, height;
    // Start is called before the first frame update
    void Start()
    {

        int[,] map_template =
        {
            {4, 0, 1, 0, 4 },
            {0, 3, 1, 3, 0 },
            {1, 1, 2, 1, 1 },
            {0, 3, 1, 3, 0 },
            {4, 0, 1, 0, 4 }
        };
        width = map_template.GetUpperBound(1) + 1;
        height = map_template.GetUpperBound(0) + 1;
        map = new GameObject[height, width];


        StreamReader reader = new StreamReader("Assets\\Scripts\\TextFile1.txt");
        
        string[] lines = reader.ReadToEnd().Split('\n');
        string[] size = lines[0].Split(' ');
        width = int.Parse(size[1]);
        height = int.Parse(size[0]);
        map_template = new int[height, width];
        map = new GameObject[height, width];
        for (int i = 0; i < height; ++i)
        {
            string[] elems = lines[i + 1].Split(' ');
            width = elems.Length;
            for(int j = 0; j < width; ++j)
            {
                map_template[i, j] = int.Parse(elems[j]);
            }
        }
        
        int count = 0;
        for(int i = 0; i < height; ++i)
        { 
            for(int j = 0; j < width; ++j)
            {
                map[i, j] = Instantiate(tiles[map_template[i, j]]);
                map[i, j].transform.SetParent(transform);
                Vector3 pos = new Vector3(i * map[i, j].transform.localScale.x, 0, j * map[i, j].transform.localScale.z);
                //Vector3 pos = Vector3.right * i * prefab.transform.localScale.x + Vector3.forward * j * prefab.transform.localScale.z;
                map[i, j].transform.localPosition = pos;
                count = (count + 1) % tiles.Length;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
