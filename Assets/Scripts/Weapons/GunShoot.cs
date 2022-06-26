using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField]
    public WeaponController _weaponController;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public Joystick joystick;
    public GameObject _gun;
    public float offset;
    public float _shootingDelay = 0.1f;
    private float rotz;
    private float _currentDelay = 0f;
    private bool _canShoot = true;
    //public Weapon _weapon;
    //public int _bulletsQuantity;

    //private void Start()
    //{
    //    _bulletsQuantity = _weapon.bulletsQuantity;
    //}

    private void Update()
    {
        if (Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
        {
            rotz = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        }
        _gun.transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        if (_canShoot == false)
        {
            _currentDelay -= Time.deltaTime;
            if (_currentDelay <= 0)
            {
                _canShoot = true;
            }
        }
        Shoot();
    }

    public void Shoot()
    {
        //if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        //{
        //    if (_bulletsQuantity > 0)
        //        if (_canShoot)
        //        {
        //            _canShoot = false;
        //            _currentDelay = _shootingDelay;
        //            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
        //            _bulletsQuantity--;
        //            //print($"{_weaponController.damage} {_weaponController.bulletsQuantity}");
        //            Destroy(bullet, 2f);
        //        }
        //}
    }
}
