using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private Grid<PathNode> _grid;
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public bool isWalkable;
    public PathNode cameFromNode;

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public PathNode(Grid<PathNode> grid, int x, int y, bool walkable)
    {
        this._grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = walkable;
        if (!walkable)
        {
            SetIsWalkable(walkable);
        }
    }

    public void SetIsWalkable(bool isWalkable)
    {
        this.isWalkable = isWalkable;
        _grid.OnTriggerGridChanged(x, y);
    }

    //public override string ToString()
    //{
    //    return x + "," + y;
    //}
}
