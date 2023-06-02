using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Configs/Level/LevelData", order = 2)]
public class LevelData : ScriptableObject
{
    public Vector2Int boardSize;
    public List<Vector2Int> listPlayerPos = new List<Vector2Int>();
    public List<Vector2Int> listWallPos = new List<Vector2Int>();
}
