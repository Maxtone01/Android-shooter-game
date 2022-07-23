using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    private void Start()
    {
        PathFinding pathFinding = new PathFinding(10, 10);
    }


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








    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
