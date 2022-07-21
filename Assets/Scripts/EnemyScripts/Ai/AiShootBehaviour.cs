using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShootBehaviour : AIBehaviour
{
    public float fovForShooting = 60;

    public override void PerformAction(EnemyController enemy, AiDetectorScript detector)
    {
        if (TargetInFOV(enemy, detector))
        {
            //enemy.HandleMoveBody(Vector2.zero);
            enemy.HandleShoot();
        }
        enemy.HandleGunAim(detector.Target.position);
    }


    private bool TargetInFOV(EnemyController enemy, AiDetectorScript detector)
    {
        var direction = detector.Target.position - enemy.aimGun.transform.position;
        if (Vector2.Angle(enemy.aimGun.transform.right, direction) < fovForShooting / 2)
        {
            return true;
        }
        return false;
    }
}
