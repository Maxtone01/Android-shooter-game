using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTransform : MonoBehaviour
{
    public Transform _gun;
    public void GunMover(Vector2 pointerPosition)
    {
        var gunDirrection = (Vector3)pointerPosition - _gun.position;
        var desiredAngle = Mathf.Atan2(gunDirrection.y, gunDirrection.x) * Mathf.Rad2Deg;
        _gun.rotation = Quaternion.RotateTowards(_gun.rotation, Quaternion.Euler(0, 0, desiredAngle), 8);
    }
}
