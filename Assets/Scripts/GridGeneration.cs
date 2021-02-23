using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanieleFramework;


public class GridGeneration : GridBase
{
    public GameObject PrefabVoid;
    public GameObject PrefabWall;
    
    //public GameObject GridBlock;
    //public GameObject Void;
    //public GameObject[,] GridArray;
    //public Vector3 OriginAngle = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //GridArray = new GameObject[Columns, Rows];
        GenerateGrid();
        //GenerateHoles();
    }


    public override void GenerateGrid()
    {
        base.GenerateGrid();

        for (int X = 0; X < GridSize.x; X++)
        {
            for (int Y = 0; Y < GridSize.y; Y++)
            {
                if(X==0)
                {
                     Instantiate(PrefabWall, CoordWalls(X-1, Y), transform.rotation);
                }
                if(Y==0)
                {
                    Instantiate(PrefabWall, CoordWalls(X, Y-1), transform.rotation);
                }
                if(X==GridSize.x-1)
                {
                    Instantiate(PrefabWall, CoordWalls(X+1, Y), transform.rotation);
                }
                if(Y==GridSize.y-1)
                {
                    Instantiate(PrefabWall, CoordWalls(X, Y+1), transform.rotation);
                }

                //Vector3 BlockPosition = new Vector3(-GridSize.x / 2 + 0.5f + X, 0, -GridSize.y / 2 + 0.5f + Y);
                //GameObject newBlock = Instantiate(Block, BlockPosition, transform.rotation);
                //newBlock.GetComponent<TileBase>().X = X;
                //newBlock.GetComponent<TileBase>().Y = Y;
                //tilebaseList.Add(newBlock);
            }
        }
    }

    Vector3 CoordWalls(int X, int Y)
    {
        return new Vector3(-GridSize.x / 2 + 0.5f + X, 0.5f, -GridSize.y / 2 + 0.5f + Y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///public override void GenerateGrid(TileBase tileBase)
    ///{
    ///    base.GenerateGrid(tileBase);
    ///    for(int Col=0; Col<MapSize.x; Col++)
    ///    {
    ///        for(int Row=0; Row<MapSize.y; Row++)
    ///        {
    ///            if(Row==0)
    ///            {
    ///                Instantiate(PrefabWall, new Vector3(Col, 0, Row - 1), transform.rotation);
    ///            }
    ///            if(Col==0)
    ///            {
    ///                Instantiate(PrefabWall, new Vector3(Col - 1, 0, Row), transform.rotation);
    ///            }
    ///            if(Row==1)
    ///            {
    ///                Instantiate(PrefabWall, new Vector3(Col, 0, Row + 1), transform.rotation);
    ///            }
    ///            if(Col==1)
    ///            {
    ///                Instantiate(PrefabWall, new Vector3(Col + 1, 0, Row), transform.rotation);
    ///            }
    ///
    ///            for(int a=0; a<mods.Length;a++)
    ///            {
    ///                if(mods[a].Position.x == Col && mods[a].Position.y == Row)
    ///                {
    ///                    if(mods[a].Type==0)
    ///                    {
    ///                        Destroy(Tile[Col, Row].gameObject);
    ///                    }
    ///                }
    ///
    ///            }
    ///        }
    ///    }
    ///}
    //public void GenerateHoles()
    //{
    //    for (int Hol = 0; Hol < Holes; Hol++)
    //    {
    //        Vector3 spawnPosition = new Vector3(Random.Range(-6, 7), 1.7f, Random.Range(-6, 7));
    //        Instantiate(Void, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
    //        //Void.transform.SetParent(gameObject.transform);
    //    }
    //}
}
