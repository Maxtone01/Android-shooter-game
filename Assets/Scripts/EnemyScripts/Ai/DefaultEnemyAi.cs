using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAi : MonoBehaviour
{
    [SerializeField]
    public AIBehaviour shootBehaviour, patrolBehaviour;

    [SerializeField]
    private EnemyController enemy;
    [SerializeField]
    private AiDetectorScript detector;

    private void Awake()
    {
        detector = GetComponentInChildren<AiDetectorScript>();
        enemy = GetComponentInChildren<EnemyController>();
    }
    private void Update()
    {
        if (detector.TargetVisible)
        {
            shootBehaviour.PerformAction(enemy, detector);
        }
        else
        {
            patrolBehaviour.PerformAction(enemy, detector);
        }
    }

}
