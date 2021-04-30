using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanieleFramework;


public class GridGeneration : GridBase
{
    public GameObject PrefabVoid;
    public GameObject PrefabWall;
    public GameObject Goal;

    public Vector2Int[] VoidsPositions;
    public Vector2Int[] WallsPositions;
    public Vector2Int GoalPosition = new Vector2Int(0, 0);

    public List<GameObject> WallList = new List<GameObject>();
    List<GameObject> GoalList = new List<GameObject>();
    
    //public GameObject GridBlock;
    //public GameObject Void;
    //public GameObject[,] GridArray;
    //public Vector3 OriginAngle = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //GridArray = new GameObject[Columns, Rows];
        GenerateGrid();
        GenerateObstacles();
        SetGoal();
    }


    public override void GenerateGrid()
    {
        base.GenerateGrid();

        //string holderName = "Generated grid";
        //if (transform.Find(holderName))
        //{
        //    DestroyImmediate(transform.Find(holderName).gameObject);
        //}
        //Transform GridHolder = new GameObject(holderName).transform;
        //GridHolder.parent = transform;

        for (int X = 0; X < GridSize.x; X++)
        {
            for (int Y = 0; Y < GridSize.y; Y++)
            {
                if(X==0)
                {
                    GameObject newWall=Instantiate(PrefabWall, CoordWalls(X-1, Y), transform.rotation);
                    newWall.transform.parent = this.transform;
                    WallList.Add(newWall);
                }
                if(Y==0)
                {
                    GameObject newWall = Instantiate(PrefabWall, CoordWalls(X, Y-1), transform.rotation);
                    newWall.transform.parent = this.transform;
                    WallList.Add(newWall);
                }
                if(X==GridSize.x-1)
                {
                    GameObject newWall = Instantiate(PrefabWall, CoordWalls(X+1, Y), transform.rotation);
                    newWall.transform.parent = this.transform;
                    WallList.Add(newWall);
                }
                if(Y==GridSize.y-1)
                {
                    GameObject newWall = Instantiate(PrefabWall, CoordWalls(X, Y+1), transform.rotation);
                    newWall.transform.parent = this.transform;
                    WallList.Add(newWall);
                }

                FindObjectOfType<Ball>().transform.position = new Vector3(GridSize.x / 2 + 0.25f, 1f, GridSize.y / 2 + 0.25f);

                //if(X==GridSize.x-1&&Y==GridSize.y-1)
                //{
                //    FindObjectOfType<Ball>().StartPosition.transform.position = newBlock.transform.position + new Vector3(0, 1, 0);
                //}

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
    public void GenerateObstacles()
    {
        foreach (GameObject Tile in tilebaseList)
        {
            for (int i = 0; i < VoidsPositions.Length; i++)
            {
                if(VoidsPositions[i].x == Tile.GetComponent<TileBase>().X && VoidsPositions[i].y == Tile.GetComponent<TileBase>().Y)
                {
                    Tile.gameObject.SetActive(false);
                }
            }
            for (int i = 0; i < WallsPositions.Length; i++)
            {
                if(WallsPositions[i].x == Tile.GetComponent<TileBase>().X && WallsPositions[i].y == Tile.GetComponent<TileBase>().Y)
                {
                    GameObject newWall=Instantiate(PrefabWall, Tile.transform.position, transform.rotation);
                    Tile.gameObject.SetActive(false);
                    newWall.transform.parent = this.transform;
                    WallList.Add(newWall);
                }
            }
        }
    }

    public void SetGoal()
    {
        foreach (GameObject Tile in tilebaseList)
        {
            if(GoalPosition.x == Tile.GetComponent<TileBase>().X && GoalPosition.y == Tile.GetComponent<TileBase>().Y)
            {
                GameObject newGoal = Instantiate(Goal, Tile.transform.position, transform.rotation);
                Tile.gameObject.SetActive(false);
                newGoal.transform.parent = this.transform;
                GoalList.Add(newGoal);
            }
        }
    }

    public void ClearList()
    {
        foreach (GameObject Tile in tilebaseList)
        {
            DestroyImmediate(Tile);
        }
        tilebaseList.Clear();
        foreach (GameObject Wall in WallList)
        {
            DestroyImmediate(Wall);
        }
        WallList.Clear();
        foreach (GameObject Goal in GoalList)
        {
            DestroyImmediate(Goal);
        }
        GoalList.Clear();
    }
}
