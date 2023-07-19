using System.Collections;
using System.Collections.Generic;
using NghiaTQ.tile;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Configs/Level/LevelData", order = 2)]
public class LevelData : ScriptableObject
{
    [Header("Size")]
    public int width;
    public int height;
    [Header("Tile data")]
    public List<TileData> listTileData;
}

[System.Serializable]
public class TileData
{
    public Vector2Int tilePos;
    public TileType tileType;
}
