using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyAI : MonoBehaviour
{
    public EnemyPathfinding _pathFinding;
    private Vector3 _startPosition;
    private Vector3 _patrolingPosition;

    private void Awake()
    {
        _pathFinding = GetComponent<EnemyPathfinding>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _patrolingPosition = GetPatrolingPosition();
    }

    private void Update()
    {
        _pathFinding.MoveTo(_patrolingPosition);
        float finalPosition = 1f;
        if (Vector3.Distance(transform.position, _patrolingPosition) < finalPosition)
        {
            _patrolingPosition = GetPatrolingPosition();
        }
    }

    ///*Getting random patroling position*/
    private Vector3 GetPatrolingPosition()
    {
        return _startPosition + GetRandomDirection() * Random.Range(10f, 70f);
    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}
