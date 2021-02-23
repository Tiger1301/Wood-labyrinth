using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DanieleFramework
{
    /// <summary>
    ///1- Classe che si occupa di generare logicamente una griglia utilizzado TILEBASE come oggetto da istanziare.
    /// 2-Add tile to List
    ///3- Ad igni tile che viene istanziata, gli viene assegnato il suo valore X e Y.
    /// </summary>
    public class GridBase : MonoBehaviour
    {
        public TileBase[,] Tile;
        public GameObject Block;
        public Vector2Int GridSize;
        public List<GameObject> tilebaseList = new List<GameObject>();

        private void Start()
        {
            
        }

        public virtual void GenerateGrid()
        {
            Tile = new TileBase[GridSize.x, GridSize.y];
            OutOfPlayGeneration();

            for (int X=0; X<GridSize.x; X++)
            {
                for(int Y=0; Y<GridSize.y; Y++)
                {
                    Vector3 BlockPosition = new Vector3(-GridSize.x / 2 + 0.5f + X, 0, -GridSize.y / 2 + 0.5f + Y);
                    GameObject newBlock = Instantiate(Block, BlockPosition, transform.rotation);
                    newBlock.GetComponent<TileBase>().X = X;
                    newBlock.GetComponent<TileBase>().Y = Y;
                    tilebaseList.Add(newBlock);
                    //TileBase tilebase = Instantiate(Tile[X, Y], BlockPosition, transform.rotation);
                    //tilebase.X = X;
                    //tilebase.Y = Y;
                }
            }
        }

        #region Testing
        /// <summary>
        /// Regione che si occupa di testare e visualizzare la crezione della griglia.
        /// </summary>
        /// <param name="VoidMap"></param>
        /// <param name="CurrentVoidCount"></param>
        /// <returns></returns>
        /// 
        public void OutOfPlayGeneration()
        {
            string holderName = "Generated grid";
            if (transform.Find(holderName))
            {
                DestroyImmediate(transform.Find(holderName).gameObject);
            }
            Transform GridHolder = new GameObject(holderName).transform;
            GridHolder.parent = transform;
        }
        #endregion

        //public Transform BlockPrefab;
        //public Transform VoidPrefab;
        //public int Seed=10;
        //public Vector2 MapSize;
        //[Range(0, 1)]
        //public float OutlinePercent;
        //[Range(0, 1)]
        //public float VoidPercent;
        //
        //List<Coord> AllBlockCoords;
        //Queue<Coord> ShuffledBlockCoords;
        //
        //Coord MapStart;
        //
        //public void GenerateGrid()
        //{
        //    AllBlockCoords = new List<Coord>();
        //    for (int X = 0; X < MapSize.x; X++)
        //    {
        //        for (int Y = 0; Y < MapSize.y; Y++)
        //        {
        //            AllBlockCoords.Add(new Coord(X, Y));
        //        }
        //    }
        //    ShuffledBlockCoords = new Queue<Coord>(TileBase.ShuffleArray (AllBlockCoords.ToArray(), Seed));
        //    MapStart = new Coord((int)MapSize.x / 2, (int)MapSize.y / 2);
        //
        //    string holderName = "Generated grid";
        //    if (transform.Find(holderName))
        //    {
        //        DestroyImmediate(transform.Find(holderName).gameObject);
        //    }
        //    Transform GridHolder = new GameObject(holderName).transform;
        //    GridHolder.parent = transform;
        //
        //    for (int X = 0; X < MapSize.x; X++)
        //    {
        //        for (int Y = 0; Y < MapSize.y; Y++)
        //        {
        //            Vector3 BlockPosition = CoordToPosition(X,Y);
        //            Transform NewBlock = Instantiate(BlockPrefab, BlockPosition, Quaternion.identity) as Transform;
        //            NewBlock.localScale = Vector3.one * (1 - OutlinePercent);
        //            NewBlock.parent = GridHolder;
        //        }
        //    }
        //
        //    bool[,] VoidMap = new bool[(int)MapSize.x, (int)MapSize.y];
        //
        //    int VoidCount = (int)(MapSize.x*MapSize.y*VoidPercent);
        //    int CurrentVoidCount = 0;
        //
        //    for(int i=0;i<VoidCount;i++)
        //    {
        //        Coord randomCoord = GetRandomCoord();
        //        VoidMap[randomCoord.x, randomCoord.y] = true;
        //        CurrentVoidCount++;
        //
        //        if((randomCoord != MapStart) && MapIsFullyAccessible(VoidMap,CurrentVoidCount))
        //        //if ((randomCoord != MapStart) && true)
        //        {
        //            Vector3 VoidPosition = CoordToPosition(randomCoord.x, randomCoord.y);
        //            Transform NewVoid = Instantiate(VoidPrefab, VoidPosition + Vector3.up * 0.5f, Quaternion.identity) as Transform;
        //            NewVoid.parent = GridHolder;
        //        }
        //        else
        //        {
        //            VoidMap[randomCoord.x, randomCoord.y] = false;
        //            CurrentVoidCount --;
        //        }
        //    }
        //}
        //
        //
        //#region Testing
        ///// <summary>
        ///// Regione che si occupa di testare e visualizzare la crezione della griglia.
        ///// </summary>
        ///// <param name="VoidMap"></param>
        ///// <param name="CurrentVoidCount"></param>
        ///// <returns></returns>
        ///// 
        //
        //#endregion
        //
        //bool MapIsFullyAccessible(bool[,] VoidMap, int CurrentVoidCount)
        //{
        //    bool[,] GridFlags = new bool[VoidMap.GetLength(0), VoidMap.GetLength(1)];
        //    Queue<Coord> queue = new Queue<Coord>();
        //    queue.Enqueue(MapStart);
        //    GridFlags[MapStart.x, MapStart.y] = true;
        //
        //    int AccessibleBlockCount = 1;
        //
        //    while(queue.Count>0)
        //    {
        //        Coord Block = queue.Dequeue();
        //        for(int x=-1; x<1; x++)
        //        {
        //            for(int y = -1; y < 1; y++)
        //            {
        //                int NeighbourX = Block.x + x;
        //                int NeighbourY = Block.y + y;
        //                if(x==0||y==0)
        //                {
        //                    if(NeighbourX >=0 && NeighbourX < VoidMap.GetLength(0) && NeighbourY >= 0 && NeighbourY < VoidMap.GetLength(1))
        //                    {
        //                        if(!GridFlags[NeighbourX,NeighbourY]&&!VoidMap[NeighbourX, NeighbourY])
        //                        {
        //                            GridFlags[NeighbourX, NeighbourY] = true;
        //                            queue.Enqueue(new Coord(NeighbourX, NeighbourY));
        //                            AccessibleBlockCount++;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    int TargetAccessibleBlocksCount = (int)(MapSize.x * MapSize.y - CurrentVoidCount);
        //    return TargetAccessibleBlocksCount == AccessibleBlockCount;
        //}
        //
        //Vector3 CoordToPosition(int X,int Y)
        //{
        //    return new Vector3(-MapSize.x / 2 + 0.5f + X, 0, -MapSize.y / 2 + 0.5f + Y);
        //}
        //
        //public Coord GetRandomCoord()
        //{
        //    Coord randomCoord = ShuffledBlockCoords.Dequeue();
        //    ShuffledBlockCoords.Enqueue(randomCoord);
        //    return randomCoord;
        //}
        //
        //public struct Coord
        //{
        //    public int x;
        //    public int y;
        //    public Coord(int _x, int _y)
        //    {
        //        x = _x;
        //        y = _y;
        //    }
        //    public static bool operator ==(Coord c1, Coord c2)
        //    {
        //        return c1.x == c2.x && c1.y == c2.y;
        //    }
        //    public static bool operator !=(Coord c1, Coord c2)
        //    {
        //        return !(c1==c2);
        //    }
        //}




        //public Texture2D Map;
        //public TileBase[] ColorMappings;
        //
        //public virtual void GenerateGrid(int _x, int _y)
        //{
        //    //string holderName = "Generated grid";
        //    //if (transform.Find(holderName))
        //    //{
        //    //    DestroyImmediate(transform.Find(holderName).gameObject);
        //    //}
        //    //Transform GridHolder = new GameObject(holderName).transform;
        //    //GridHolder.parent = transform;
        //
        //    for (int x = 0; x < Map.width; x++)
        //    {
        //        for (int y = 0; y < Map.height; y++)
        //        {
        //            GenerateBlock(x, y);
        //        }
        //    }
        //}
        //public void GenerateBlock(int x, int y)
        //{
        //    Color PixelColor = Map.GetPixel(x, y);
        //
        //    if (PixelColor.a == 0)
        //    {
        //        return;
        //    }
        //
        //    foreach (TileBase ColorMapping in ColorMappings)
        //    {
        //        if (ColorMapping.Color.Equals(PixelColor))
        //        {
        //            Vector3 Position = new Vector3(x, 0, y);
        //            Instantiate(ColorMapping.prefab, Position, Quaternion.identity);
        //        }
        //    }
        //}
    }
}