using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Linq;

public class Board : MonoBehaviour
{
    private Dictionary<Vector2, Tile> m_grid = new Dictionary<Vector2, Tile>();

    [SerializeField] private Tile m_tilePrefab;
    [SerializeField] private Tank m_tankPrefab;

    [SerializeField] private LevelConfig levelConfig;

    private List<Tile> listTile;

    private void Start()
    {
        DoStart();
    }

    public void DoStart()
    {
        SetUp();
    }

    void SetUp()
    {
        listTile = new List<Tile>();
        var levelData = levelConfig.GetLevelData(1);
        var listPlayerPos = levelData.listPlayerPos;
        var listWallPos = levelData.listWallPos;
        Vector2Int boardSize = levelData.boardSize;
        m_grid.Clear();
        for (int x = 0; x < boardSize.x; x++)
        {
            for (int y = 0; y < boardSize.y; y++)
            {
                var tile = Instantiate(m_tilePrefab, new Vector2(x, y), Quaternion.identity, transform);
                tile.name = "tile_" + x + "_" + y;

                //set path node for this tile
                PathNode tempNode = new PathNode(x, y);
                tile.tileNode = tempNode;
                listTile.Add(tile);

                tile.coordinate = new Vector2Int(x, y);
                m_grid.Add(new Vector2(x, y), tile);
            }
        }

        // set neighbors for node
        
        SetNeighborsForNode(boardSize);

        foreach(var pos in listPlayerPos)
        {
            Instantiate(m_tankPrefab, m_grid[pos].transform.position, Quaternion.identity, m_grid[pos].transform);
        }
        foreach(var pos in listWallPos)
        {
            m_grid[pos].SetTileWall();
        }

        //test///////////////////////////////////////////////////
        PathFinding pathFinding = new PathFinding(listTile);
        List<Tile> path = path = pathFinding.FindPath(new Vector2Int(5, 1), new Vector2Int(2, 2));
        foreach(var i in path)
        {
            Debug.Log(i.tileNode.gridPosition.x + " " + i.tileNode.gridPosition.y + "pp" + " " + i.gameObject.name);
        }
        ///////////////////////////////////////////////////////////
    }

    private void SetNeighborsForNode(Vector2Int boardSize) 
    {
        foreach(var tile in listTile)
        {
            if(tile.tileNode.gridPosition.x != boardSize.x-1)
            {
                Vector2Int newGridPos = new Vector2Int(tile.tileNode.gridPosition.x+1, tile.tileNode.gridPosition.y);
                Tile upTile = GetTileAtPos(newGridPos);
                tile.tileNode.neighbors.Add(upTile);
            }
            if(tile.tileNode.gridPosition.x != 0)
            {
                Vector2Int newGridPos = new Vector2Int(tile.tileNode.gridPosition.x - 1, tile.tileNode.gridPosition.y);
                Tile downTile = GetTileAtPos(newGridPos);
                tile.tileNode.neighbors.Add(downTile);
            }
            if(tile.tileNode.gridPosition.y != boardSize.y-1)
            {
                Vector2Int newGridPos = new Vector2Int(tile.tileNode.gridPosition.x, tile.tileNode.gridPosition.y+1);
                Tile leftTile = GetTileAtPos(newGridPos);
                tile.tileNode.neighbors.Add(leftTile);
            }
            if(tile.tileNode.gridPosition.y != 0)
            {
                Vector2Int newGridPos = new Vector2Int(tile.tileNode.gridPosition.x, tile.tileNode.gridPosition.y-1);
                Tile rightTile = GetTileAtPos(newGridPos);
                tile.tileNode.neighbors.Add(rightTile);
            }
        } 
    }

    private Tile GetTileAtPos(Vector2Int pos)
    {
        Tile findTile = listTile.FirstOrDefault(tile => tile.tileNode.gridPosition.x == pos.x && tile.tileNode.gridPosition.y == pos.y);
        return findTile;
    }
}
