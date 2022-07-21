using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    private float gunRotationSpeed = 100;

    public void Aim(Vector2 inputPointerPosition)
    {
        var aimDirrection = (Vector3)inputPointerPosition - transform.position;

        var desiredAngle = Mathf.Atan2(aimDirrection.y, aimDirrection.x) * Mathf.Rad2Deg;

        var rotationSpeed = gunRotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle), rotationSpeed);
    }
}
