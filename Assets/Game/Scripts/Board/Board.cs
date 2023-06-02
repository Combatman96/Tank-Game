using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Dictionary<Vector2, Tile> m_grid = new Dictionary<Vector2, Tile>();

    [SerializeField] private Tile m_tilePrefab;
    [SerializeField] private Tank m_tankPrefab;

    [SerializeField] private LevelConfig levelConfig;

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
                tile.coordinate = new Vector2Int(x, y);
                m_grid.Add(new Vector2(x, y), tile);
            }
        }
        foreach(var pos in listPlayerPos)
        {
            Instantiate(m_tankPrefab, m_grid[pos].transform.position, Quaternion.identity, m_grid[pos].transform);
        }
        foreach(var pos in listWallPos)
        {
            m_grid[pos].SetTileWall();
        }
    }

}
