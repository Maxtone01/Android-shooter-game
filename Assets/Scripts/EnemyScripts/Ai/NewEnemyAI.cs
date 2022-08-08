using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyAI : MonoBehaviour
{
    //public float finalPosition = 1f;
    [SerializeField]
    public EnemyPathfinding _pathFinding;
    private Vector3 _startPosition;
    private Vector3 _patrolingPosition;
    [SerializeField]
    public AIBehaviour shootBehaviour;
    [SerializeField]
    private EnemyController enemy;
    [SerializeField]
    private AiDetectorScript detector;
    private enum State
    { 
        Roaming,
        Chasing,
        GoToStart
    }
    private State _state;

    private void Awake()
    {
        _pathFinding = GetComponent<EnemyPathfinding>();
        _state = State.Roaming;
        detector = GetComponentInChildren<AiDetectorScript>();
        enemy = GetComponentInChildren<EnemyController>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _patrolingPosition = GetPatrolingPosition();
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Roaming:
                _pathFinding.MoveTo(_patrolingPosition);

                float finalPosition = 1f;
                if (Vector3.Distance(transform.position, _patrolingPosition) < finalPosition)
                {
                    _patrolingPosition = GetPatrolingPosition();
                }
                FindTarget();
                break;

            case State.Chasing:
                _pathFinding.MoveTo(PlayerScript.Instance.transform.position);

                if (detector.TargetVisible)
                {
                    shootBehaviour.PerformAction(enemy, detector);
                    _pathFinding.StopMoving();
                }

                float stopChaseDistance = 17f;
                //float attackRange = 10f;
                //if (Vector3.Distance(transform.position, PlayerScript.Instance.transform.position) > stopChaseDistance)
                if (!detector.TargetVisible)
                {
                    _state = State.GoToStart;
                }
                break;

            case State.GoToStart:
                _pathFinding.MoveTo(_startPosition);

                float reachedPositionDistance = 10f;
                if (Vector3.Distance(transform.position, PlayerScript.Instance.transform.position) > reachedPositionDistance)
                    _state = State.Roaming;
                break;
        }

        //_pathFinding.MoveToTimer(_patrolingPosition);

        //float finalPosition = 1f;
        //if (Vector3.Distance(transform.position, _patrolingPosition) < finalPosition)
        //{
        //    _patrolingPosition = GetPatrolingPosition();
        //    print(_patrolingPosition);
        //}
    }

    ///*Getting random patroling position*/
    private Vector3 GetPatrolingPosition()
    {
        return _startPosition + GetRandomDirection() * Random.Range(3f, 3f);
    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private void FindTarget()
    {
        if (detector.TargetVisible)
        {
            print("Found player...");
            _state = State.Chasing;
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 5f);
    //}
}
