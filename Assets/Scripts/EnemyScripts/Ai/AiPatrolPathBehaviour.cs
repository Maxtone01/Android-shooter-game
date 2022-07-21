using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrolPathBehaviour : AIBehaviour
{
    public PatrolPath patrolPath;
    [Range(0.1f, 1)]
    public float arrivedDistance = 1;
    public float sleepTime = 0.5f;
    [SerializeField]
    private bool isWaiting = false;
    [SerializeField]
    Vector2 currentPatrolTarget = Vector2.zero;
    bool isInitalized = false;

    private int currentIndex = -1;

    private void Awake()
    {
        if (patrolPath == null)
            patrolPath = GetComponentInChildren<PatrolPath>();
    }

    public override void PerformAction(EnemyController enemy, AiDetectorScript detector)
    {
        if (!isWaiting)
        {
            if (patrolPath.Length < 2)
                return;
            if (!isInitalized)
            {
                var currentPathPoint = patrolPath.GetClosestPathPoint(enemy.transform.position);
                this.currentIndex = currentPathPoint.Index;
                this.currentPatrolTarget = currentPathPoint.Position;
                isInitalized = true;
            }
            if (Vector2.Distance(enemy.transform.position, currentPatrolTarget) < arrivedDistance)
            {
                isWaiting = true;
                StartCoroutine(WaitCoroutine());
                return;
            }
            enemy.HandleMoveBody(currentPatrolTarget);
            //Vector2 directionToGo = currentPatrolTarget - (Vector2)enemy.enemyMover.transform.position;
            //var dotProduct = Vector2.Dot(enemy.enemyMover.transform.up, directionToGo.normalized);

            //if (dotProduct < 0.98f)
            //{
            //    var crossProduct = Vector3.Cross(enemy.enemyMover.transform.up, directionToGo.normalized);
            //    int rotationResult = crossProduct.z >= 0 ? -1 : 1;
            //    enemy.HandleMoveBody(new Vector2(rotationResult, 1));
            //}
            //else
            //{
            //    enemy.HandleMoveBody(Vector2.up);
            //}
        }
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(sleepTime);
        var nextPathPoint = patrolPath.GetNextPathPoint(currentIndex);
        currentPatrolTarget = nextPathPoint.Position;
        currentIndex = nextPathPoint.Index;
        isWaiting = false;
    }
}
