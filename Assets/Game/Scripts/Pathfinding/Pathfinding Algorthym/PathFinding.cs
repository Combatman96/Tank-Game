using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PathFinding 
{
    private const int MOVE_STRAIGHT_COST = 1;
    private  List<Tile> openList;
    private  List<Tile> clostList;
    public List<Tile> baseGrid;

    public PathFinding(List<Tile> baseGrid)
    {
        this.baseGrid = baseGrid;
    }

    public List<Tile> FindPath(Vector2Int start, Vector2Int end) 
    {
        //setup
        ResetCostForNode();
        openList = new List<Tile>();
        clostList = new List<Tile>();

        Tile startNode = baseGrid.FirstOrDefault(tile => tile.tileNode.gridPosition.x == start.x && tile.tileNode.gridPosition.y == start.y);
        Tile endNode = baseGrid.FirstOrDefault(tile => tile.tileNode.gridPosition.x == end.x && tile.tileNode.gridPosition.y == end.y);

        openList.Add(startNode);

        startNode.tileNode.gCost = 0;
        startNode.tileNode.hCost = CalculateDistance(startNode.tileNode, endNode.tileNode);
        startNode.tileNode.CalculateFCost();

        while(openList.Count > 0)
        {
            Tile currentNode = GetLowestFCostNode();
            if(currentNode == endNode)
            {
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            clostList.Add(currentNode);

            foreach(var neighbor in currentNode.tileNode.neighbors)
            {
                if(!clostList.Contains(neighbor) && neighbor.tileNode.isWalkable && neighbor.CompareTag("Ground"))
                {
                    int newGCost = currentNode.tileNode.gCost + CalculateDistance(currentNode.tileNode, neighbor.tileNode);
                    if(newGCost < neighbor.tileNode.gCost)
                    {
                        neighbor.tileNode.gCost = newGCost;
                    }
                    neighbor.tileNode.hCost = CalculateDistance(neighbor.tileNode, endNode.tileNode);
                    neighbor.tileNode.CalculateFCost();
                    neighbor.tileNode.previousNode = currentNode;

                    if(openList.Contains(neighbor))
                    {
                        //replace by lower fCost version
                    }
                    else
                    {
                        openList.Add(neighbor);
                    }
                }
            }
        }

        return null;
    }

    public void ResetCostForNode()
    {
        foreach(var i in baseGrid)
        {
            i.tileNode.fCost = 0;
            i.tileNode.gCost = int.MaxValue;
            i.tileNode.hCost = 0;
            i.tileNode.previousNode = null;
        }
    }

    private int CalculateDistance(PathNode startNode, PathNode endNode)
    {
        int distance = Mathf.Abs(startNode.gridPosition.x - endNode.gridPosition.x)
            + Mathf.Abs(startNode.gridPosition.y - endNode.gridPosition.y);

        return distance * MOVE_STRAIGHT_COST;
    }
    
    private Tile GetLowestFCostNode()
    {
        //sort openList by fCost;
        openList.Sort((node1, node2) => node1.tileNode.fCost.CompareTo(node2.tileNode.fCost));
        return openList[0];
    }

    private List<Tile> CalculatePath(Tile endNode)
    {
        List<Tile> path = new List<Tile>();
        path.Add(endNode);
        BackTrackNode(path, endNode);
        path.Reverse(); 
        return path;
    }

    private void BackTrackNode(List<Tile> path ,Tile node)
    {
        if(node.tileNode.previousNode != null)
        {
            path.Add(node.tileNode.previousNode);
            BackTrackNode(path, node.tileNode.previousNode);
        }

        return;
    }
}

