using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon _pistol, _riffle;
    public GunShoot _gunShoot;
    public Weapon equippedWeapon;
    [SerializeField]
    private PlayerScript _playerScript;
    [SerializeField]
    private Transform _weaponSlot;
    private GameObject _currentWeapon;
    public int _bulletsPistol, _bulletsRiffle;
    public GameObject _activePistol, _activeRiffle;

    public List<Weapon> weapons;

    private void Start()
    {
        _gunShoot = GetComponent<GunShoot>();

        _activePistol = Instantiate(_pistol.weaponPrefab);
        _activePistol.SetActive(false);
        _activePistol.transform.SetParent(_weaponSlot);
        _activePistol.transform.localPosition = Vector3.zero;
        _activePistol.transform.localRotation = Quaternion.identity;
        _bulletsPistol = _pistol.bulletsQuantity;
        _gunShoot._shootingDelay = _pistol.shootingDelay;

        _activeRiffle = Instantiate(_riffle.weaponPrefab);
        _activeRiffle.SetActive(false);
        _activeRiffle.transform.SetParent(_weaponSlot);
        _activeRiffle.transform.localPosition = Vector3.zero;
        _activeRiffle.transform.localRotation = Quaternion.identity;
        _bulletsRiffle = _riffle.bulletsQuantity;
        _gunShoot._shootingDelay = _riffle.shootingDelay;
    }

    public void SetWeaponData(string _weaponType)
    {
        switch (_weaponType)
        {
            case "Pistol":
                _activePistol.SetActive(true);
                _activeRiffle.SetActive(false);
                Counter.quantity = _bulletsPistol;
                break;
            case "Riffle":
                _activePistol.SetActive(false);
                _activeRiffle.SetActive(true);
                Counter.quantity = _bulletsRiffle;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            print("Reloaded");
            Reload();
        }
    }

    private void Reload()
    {
        if (_activePistol.activeSelf)
        {
            _bulletsPistol = _pistol.bulletsQuantity;
            Counter.quantity = _bulletsPistol;
            print("Reloaded Pistol");
        }
        if (_activeRiffle.activeSelf)
        {
            _bulletsRiffle = _riffle.bulletsQuantity;
            Counter.quantity = _bulletsRiffle;
            print("Reloaded Riffle");
        }
    }
}
