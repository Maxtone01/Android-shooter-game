using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    private const float _speed = 30f;
    private EnemyController _enemyController;
    private List<Vector3> _pathVectorList;
    private int _currentPathIndex;
    private float _pathfindingTimer;
    private Vector3 _moveDir;
    private Vector3 _lastMoveDir;

    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
    }

    private void Update()
    {
        _pathfindingTimer -= Time.deltaTime;
        HandleMovement();
    }

    private void FixedUpdate()
    {
        _enemyController.rb2d.velocity = _moveDir * _speed;
    }

    private void HandleMovement()
    {
        PrintPathFindingPath();
        if (_pathVectorList != null)
        {
            Vector3 targetPosition = _pathVectorList[_currentPathIndex];
            float reachedTarget = 5f;
            if (Vector3.Distance(GetPosition(), targetPosition) > reachedTarget)
            {
                _moveDir = (targetPosition - GetPosition()).normalized;
                _lastMoveDir = _moveDir;
                /*Should play animation of moving*/
            }
            else
            {
                _currentPathIndex++;
                if (_currentPathIndex >= _pathVectorList.Count)
                {
                    StopMoving();
                    /*Should play idle*/
                }
            }
        }
        else
        { 
            /*Should play idle*/
        }
    }

    private void StopMoving()
    {
        _pathVectorList = null;
        _moveDir = Vector3.zero;
    }

    private List<Vector3> GetpathVectorList() 
    {
        return _pathVectorList;
    }

    private void PrintPathFindingPath()
    {
        if (_pathVectorList != null)
        {
            for (int i = 0; i < _pathVectorList.Count - 1; i++)
            {
                Debug.DrawLine(_pathVectorList[i], _pathVectorList[i + 1]);
            }
        }
    }

    public void MoveTo(Vector3 targetPosition)
    {
        SetTargetPosition(targetPosition);
    }

    private void SetTargetPosition(Vector3 targetPosition)
    {
        //_pathVectorList = GridPathfinding.instance.GetPathRouteWithShortcuts(GetPosition(), targetPosition).pathVectorList;
        _currentPathIndex = 0;
        _pathfindingTimer = .2f;

        if(_pathVectorList != null && _pathVectorList.Count > 1)
            _pathVectorList.RemoveAt(0);
    }
    private Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetLastMoveDir()
    {
        return _lastMoveDir;
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
        _enemyController.rb2d.velocity = Vector3.zero;
    }
}