using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchSystem: MonoBehaviour
{
    [SerializeField]
    public Weapon _pistol, _riffle;
    public enum WeaponType
    { 
        Pistol,
        Riffle,
    }
    private WeaponController _weaponController;
    private List<Weapons> weaponList;

    public WeaponSwitchSystem(WeaponController _weapon)
    {
        this._weaponController = _weapon;
        weaponList = new List<Weapons>();
        weaponList.Add(new Weapons
        {
            weaponTypes = WeaponType.Pistol,
            swapWeapon = () => _weaponController.SetWeapon(_pistol)
        });
        weaponList.Add(new Weapons
        {
            weaponTypes = WeaponType.Riffle,
            swapWeapon = () => _weaponController.SetWeapon(_riffle)
        });
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponList[0].swapWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponList[1].swapWeapon();
        }
    }

    public class Weapons 
    {
        public WeaponType weaponTypes;
        public Action swapWeapon;
    }
}
