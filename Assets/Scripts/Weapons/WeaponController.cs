using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //[SerializeField]
    //private ScriptableObject _pistol, _riffle;
    //[SerializeField]
    //private WeaponType equippedWeapon;
    [SerializeField]
    private PlayerScript _playerScript;
    [SerializeField]
    private Transform _weaponSlot;
    private GameObject _currentWeapon;
    //private Weapon _weaponBullets;
    //public int _bulletsQuantity;

    public enum WeaponType
    {
        Pistol,
        Riffle,

    }
    public WeaponType weaponType;

    public void SetWeapon(Weapon _weaponType)
    {
        //GameObject weapon = _weaponType switch
        //{
        //Weapon.WeaponType.Riffle => _riffle,
        //Weapon.WeaponType.Pistol => _pistol,
        //_ => throw new System.NotImplementedException()
        //};
        if (_currentWeapon != null)
            Destroy(_currentWeapon);
        //switch (weaponName)
        //{
        //    case Weapon.WeaponType.Pistol:
        _currentWeapon = Instantiate(_weaponType.weaponPrefab);
        _currentWeapon.transform.SetParent(_weaponSlot);
        _currentWeapon.transform.localPosition = Vector3.zero;
        _currentWeapon.transform.localRotation = Quaternion.identity;
        //        print(_currentWeapon);
        //        break;
        //    case Weapon.WeaponType.Riffle:
        //        _currentWeapon = Instantiate(_weaponType.weaponPrefab);
        //        _currentWeapon.transform.SetParent(_weaponSlot);
        //        _currentWeapon.transform.localPosition = Vector3.zero;
        //        _currentWeapon.transform.localRotation = Quaternion.identity;
        //        print(_currentWeapon);
        //        break;
        //}
        //_currentWeapon = Instantiate(weapon);
        //_currentWeapon.transform.SetParent(_weaponSlot);
        //_currentWeapon.transform.localPosition = Vector3.zero;
        //_currentWeapon.transform.localRotation = Quaternion.identity;
        //print(_currentWeapon);
    }
}
