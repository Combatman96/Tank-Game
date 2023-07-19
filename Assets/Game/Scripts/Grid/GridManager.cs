using NghiaTQ.tile;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEditor;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _witdh, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    [SerializeField] private int level;

    private Dictionary<Vector2Int, Tile> _tiles;
    private List<TileData> _listTileData;

    public static List<Tile> selectedTiles;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        selectedTiles = new List<Tile>();
        _tiles = new Dictionary<Vector2Int, Tile>();
        for (int x = 0; x < _witdh; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
                spawnedTile.name = $"Tile {x} {y}";
                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                spawnedTile.TilePos = new Vector2Int(x, y);
                spawnedTile.TileType = TileType.NORMAL;
                _tiles[spawnedTile.TilePos] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_witdh / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

    public Tile GetTileAtPos(Vector2Int pos)
    {
        if (_tiles.TryGetValue(pos, out Tile tile))
        {
            return tile;
        }
        return null;
    }

    private void Update()
    {
        if (selectedTiles.Count == 0) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeTileType(TileType.OBSTANCE, Color.black);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeTileType(TileType.PLAYER, Color.green);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeTileType(TileType.ENEMY, Color.red);
        }
    }

    private void ChangeTileType(TileType type, Color typeColor)
    {
        foreach (var tile in selectedTiles)
        {
            if (tile.TileType == type)
            {
                BackToOrigin();
                return;
            }

            tile.TileType = type;
            tile.GetComponent<SpriteRenderer>().color = typeColor;
            tile.IsSelected = !tile.IsSelected;
        }
        selectedTiles.Clear();
    }


    private void BackToOrigin()
    {
        foreach (var tile in selectedTiles)
        {
            int temp = (tile.TilePos.x + tile.TilePos.y) % 2;
            bool isOffset = temp != 0;
            tile.Init(isOffset);
            tile.TileType = TileType.NORMAL;
            tile.IsSelected = !tile.IsSelected;
        }
    }

#if UNITY_EDITOR
    [Button]
    public void SaveData()
    {
        LevelData levelData = ScriptableObject.CreateInstance<LevelData>();
        string path = "Assets/Game/Configs/level_" + level + ".asset";
        _listTileData = new List<TileData>();
        Tile[] tiles = this.transform.GetComponentsInChildren<Tile>();
        foreach (var tile in tiles)
        {
            TileData tileData = new TileData();
            tileData.tilePos = tile.TilePos;
            tileData.tileType = tile.TileType;

            _listTileData.Add(tileData);
        }

        levelData.width = _witdh;
        levelData.height = _height;
        levelData.listTileData = _listTileData;

        AssetDatabase.CreateAsset(levelData, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
#endif
}

