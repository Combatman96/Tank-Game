using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode 
{
    public Vector2Int gridPosition;

    public PathNode previousNode;

    public int fCost;
    public int hCost;
    public int gCost;

    public List<PathNode> neighbors;
    public bool isChecked;
    public bool isWalkable;

    public PathNode() {}

    public PathNode(int x, int y)
    {
        this.gridPosition = new Vector2Int(x, y);
        this.fCost = 0;
        this.gCost = 0;
        this.hCost = 0;
        this.previousNode = null;
        this.neighbors = new List<PathNode>();
        this.isChecked = false;
        this.isWalkable = true;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
}
