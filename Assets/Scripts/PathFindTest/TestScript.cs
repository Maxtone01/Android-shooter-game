using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    private EnemyPathfinding _enemyPathFinding;

    private PathFinding _pathFinding;
    private void Start()
    {
        _pathFinding = new PathFinding(20, 20);
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector3 mouseWorldPosition = GetMouseWorldPosition();
    //        _pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
    //        List<PathNode> path = _pathFinding.FindPath(0, 0, x, y);
    //        if (path != null)
    //        {
    //            for (int i = 0; i < path.Count - 1; i++)
    //            {
    //                Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f,
    //                    new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green);
    //            }
    //        }
    //        _enemyPathFinding.SetTargetPosition(mouseWorldPosition);
    //    }
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        Vector3 mouseWorldPosition = GetMouseWorldPosition();
    //        _pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
    //        _pathFinding.GetNode(x, y).SetIsWalkable(!_pathFinding.GetNode(x, y).isWalkable);
    //    }
    //}


    //private Grid<bool> grid;
    //private void Start()
    //{
    //    grid = new Grid<bool>(4, 2, 10f, new Vector3(20, 0));
    //}

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        grid.SetValue(GetMouseWorldPosition(), false);
    //    }
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        Debug.Log(grid.GetValue(GetMouseWorldPosition()));
    //    }
    //}








    //public static Vector3 GetMouseWorldPosition()
    //{
    //    Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    //    vec.z = 0f;
    //    return vec;
    //}

    //public static Vector3 GetMouseWorldPositionWithZ()
    //{
    //    return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    //}

    //public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    //{
    //    return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    //}

    //public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    //{
    //    Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
    //    return worldPosition;
    //}
}
