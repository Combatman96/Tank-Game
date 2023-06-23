using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathFinding 
{
    private const int MOVE_STRAIGHT_COST = 1;
    private  List<PathNode> openList;
    private  List<PathNode> clostList;
    public List<PathNode> baseGrid;

    public PathFinding(List<PathNode> baseGrid)
    {
        this.baseGrid = baseGrid;
    }

    public List<PathNode> FindPath(Vector2Int start, Vector2Int end) 
    {
        //setup
        ResetCostForNode();
        openList = new List<PathNode>();
        clostList = new List<PathNode>();

        PathNode startNode = baseGrid.FirstOrDefault(node => node.gridPosition.x == start.x && node.gridPosition.y == start.y);
        PathNode endNode = baseGrid.FirstOrDefault(node => node.gridPosition.x == end.x && node.gridPosition.y == end.y);

        openList.Add(startNode);

        startNode.gCost = 0;
        startNode.hCost = ClaculateDistance(startNode, endNode);
        startNode.CalculateFCost();

        while(openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode();
            if(currentNode == endNode)
            {
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            clostList.Add(currentNode);

            foreach(var neighbor in currentNode.neighbors)
            {
                if(!clostList.Contains(neighbor) && neighbor.isWalkable)
                {
                    int newGCost = currentNode.gCost + ClaculateDistance(currentNode, neighbor);
                    if(newGCost < neighbor.gCost)
                    {
                        neighbor.gCost = newGCost;
                    }
                    neighbor.hCost = ClaculateDistance(neighbor, endNode);
                    neighbor.CalculateFCost();
                    neighbor.previousNode = currentNode;

                    if(openList.Contains(neighbor))
                    {
                        //replece by lower fCost version
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
            i.fCost = 0;
            i.gCost = int.MaxValue;
            i.hCost = 0;
            i.previousNode = null;
        }
    }

    private int ClaculateDistance(PathNode startNode, PathNode endNode)
    {
        int distance = Mathf.Abs(startNode.gridPosition.x - endNode.gridPosition.x)
            + Mathf.Abs(startNode.gridPosition.y - endNode.gridPosition.y);

        return distance * MOVE_STRAIGHT_COST;
    }
    
    private PathNode GetLowestFCostNode()
    {
        //sort openList by fCost;
        openList.Sort((node1, node2) => node1.fCost.CompareTo(node2.fCost));
        return openList[0];
    }

    private List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        BackTrackNode(path, endNode);
        path.Reverse(); 
        return path;
    }

    private void BackTrackNode(List<PathNode> path ,PathNode node)
    {
        if(node.previousNode != null)
        {
            path.Add(node.previousNode);
            BackTrackNode(path, node.previousNode);
        }

        return;
    }
}

