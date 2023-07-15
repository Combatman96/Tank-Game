using NghiaTQ.tile;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _witdh, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < _witdh; x++)
        {
            for(int y =0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab,new Vector3(x,y,0),Quaternion.identity,transform);
                spawnedTile.name = $"Tile {x} {y}";
                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0) ;
                spawnedTile.Init(isOffset);
            }
        }

        _cam.transform.position = new Vector3((float)_witdh / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
}

