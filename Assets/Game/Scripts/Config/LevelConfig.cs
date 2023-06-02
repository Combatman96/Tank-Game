using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/Level/LevelConfig", order = 1)]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private List<LevelData> m_levelDatas = new List<LevelData>();

    public LevelData GetLevelData(int level)
    {
        return m_levelDatas[level - 1];
    }
}
