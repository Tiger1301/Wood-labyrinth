using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneration : MonoBehaviour
{
    public int Columns;
    public int Rows;
    public float Scale;
    public GameObject WallBlock;
    public GameObject[,] WallArray;
    public Vector3 WallAngle = new Vector3(-1, 0, -1);
    // Start is called before the first frame update
    void Start()
    {
        WallArray = new GameObject[Columns, Rows];
        GenerateWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateWalls()
    {
        for (int WallCol = 0; WallCol < Columns; WallCol++)
        {
            for (int WallRow = 0; WallRow < Rows; WallRow++)
            {
                GameObject Wall = Instantiate(WallBlock, new Vector3(WallAngle.x + Scale * WallCol, WallAngle.y, WallAngle.z + Scale * WallRow), Quaternion.identity);
                Wall.transform.SetParent(gameObject.transform);
            }
        }
    }
}
