using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSetup : MonoBehaviour
{
    [SerializeField]
    private EnemyPathfinding _enemyPathFinding;

    public int _width;
    public int _height;

    public LayerMask unwalkableMask;

    private PathFinding _pathFinding;
    private void Start()
    {
        _pathFinding = new PathFinding(_width, _height, unwalkableMask);
    }
}
