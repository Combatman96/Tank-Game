using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode 
{
    public Vector2Int gridPosition;

    public Tile previousNode;

    public int fCost;
    public int hCost;
    public int gCost;

    public List<Tile> neighbors;
    public bool isWalkable;

    public PathNode() {}

    public PathNode(int x, int y)
    {
        this.gridPosition = new Vector2Int(x, y);
        this.fCost = 0;
        this.gCost = int.MaxValue;
        this.hCost = 0;
        this.previousNode = null;
        this.neighbors = new List<Tile>();
        this.isWalkable = true;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
}
