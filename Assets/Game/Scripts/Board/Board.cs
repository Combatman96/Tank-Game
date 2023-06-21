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

    private List<PathNode> grid;

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
        grid = new List<PathNode>();
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

                //set path node for this tile
                PathNode tempNode = new PathNode(x, y);
                grid.Add(tempNode);

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
    }

    private void SetNeighborsForNode(Vector2Int boardSize) 
    {
        foreach(var node in grid)
        {
            Debug.Log(node.gridPosition.x + " " + node.gridPosition.y);

            if(node.gridPosition.x != boardSize.x-1)
            {
                Vector2Int newGridPos = new Vector2Int(node.gridPosition.x+1, node.gridPosition.y);
                PathNode upNode = GetNodeAtPos(newGridPos);
                node.neighbors.Add(upNode);
            }
            if(node.gridPosition.x != 0)
            {
                Vector2Int newGridPos = new Vector2Int(node.gridPosition.x - 1, node.gridPosition.y);
                PathNode downNode = GetNodeAtPos(newGridPos);
                node.neighbors.Add(downNode);
            }
            if(node.gridPosition.y != boardSize.y-1)
            {
                Vector2Int newGridPos = new Vector2Int(node.gridPosition.x, node.gridPosition.y+1);
                PathNode leftNode = GetNodeAtPos(newGridPos);
                node.neighbors.Add(leftNode);
            }
            if(node.gridPosition.y != 0)
            {
                Vector2Int newGridPos = new Vector2Int(node.gridPosition.x, node.gridPosition.y-1);
                PathNode rightNode = GetNodeAtPos(newGridPos);
                node.neighbors.Add(rightNode);
            }
        }

        
    }

    private PathNode GetNodeAtPos(Vector2Int pos)
    {
        PathNode findNode = new PathNode();
        findNode = grid.FirstOrDefault(node => node.gridPosition.x == pos.x && node.gridPosition.y == pos.y);
        return findNode;
    }
}
