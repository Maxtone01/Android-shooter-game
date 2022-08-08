using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    private const float _speed = 20f;
    private List<Vector3> _pathVectorList;
    private int _currentPathIndex;
    private float _pathfindingTimer;
    private Vector3 _moveDir;
    private Vector3 _lastMoveDir;
    private PathFinding _pathFinding;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _pathfindingTimer -= Time.deltaTime;

        HandleMovement();
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = _moveDir * _speed;
        //_enemyController.rb2d.velocity = _moveDir * _speed;
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

    public void StopMoving()
    {
        _pathVectorList = null;
        _moveDir = Vector3.zero;
    }

    private List<Vector3> GetPathVectorList() 
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

    public void MoveToTimer(Vector3 targetPosition)
    {
        if (_pathfindingTimer <= 0)
        {
            SetTargetPosition(targetPosition);
        }
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _currentPathIndex = 0;

        _pathVectorList = PathFinding.Instance.FindPath(GetPosition(), targetPosition);
        _pathfindingTimer = .1f;

        if (_pathVectorList != null && _pathVectorList.Count > 1)
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
        _rb2d.velocity = Vector3.zero;
    }
}
