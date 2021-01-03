using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration : MonoBehaviour
{
    public int Rows;
    public int Columns;
    public int Holes;
    public float Scale;
    public GameObject GridBlock;
    public GameObject Void;
    public GameObject[,] GridArray;
    public Vector3 OriginAngle = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        GridArray = new GameObject[Columns, Rows];
        GenerateGrid();
        GenerateHoles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        for(int Col = 0; Col < Columns; Col++)
        {
            for(int Row=0; Row<Rows; Row++)
            {
                GameObject Block = Instantiate(GridBlock, new Vector3(OriginAngle.x + Scale * Col, OriginAngle.y, OriginAngle.z + Scale * Row), Quaternion.identity);
                Block.transform.SetParent(gameObject.transform);
                GridArray[Col, Row] = Block;
            }
        }
    }
    public void GenerateHoles()
    {
        for (int Hol = 0; Hol < Holes; Hol++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-6, 7), 1.7f, Random.Range(-6, 7));
            Instantiate(Void, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        }
    }
}
