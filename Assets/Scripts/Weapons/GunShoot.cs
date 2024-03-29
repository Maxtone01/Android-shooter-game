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
    public float _shootingDelay;

    private float rotz;
    private float _currentDelay = 0f;
    private bool _canShoot = true;
    //public int _bulletsQuantity;

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
        if (_weaponController._activePistol.activeSelf)
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                if (_weaponController.bulletsPistol > 0)
                    if (_canShoot)
                    {
                        _canShoot = false;
                        _currentDelay = _shootingDelay;

                        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
                        _weaponController.bulletsPistol--;
                        Counter.quantity--;

                        Destroy(bullet, 2f);
                    }

                if (_weaponController.bulletsPistol == 0)
                   StartCoroutine(_weaponController.Reload());
            }
            if (_weaponController._activeRiffle.activeSelf)
                if (joystick.Horizontal != 0 || joystick.Vertical != 0)
                {
                    if (_weaponController.bulletsRiffle > 0)
                        if (_canShoot)
                        {
                            _canShoot = false;
                            _currentDelay = _shootingDelay;

                            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
                            _weaponController.bulletsRiffle--;
                            Counter.quantity--;

                            Destroy(bullet, 2f);
                        }

                    if (_weaponController.bulletsRiffle == 0)
                        StartCoroutine(_weaponController.Reload());
            }
    }
}
