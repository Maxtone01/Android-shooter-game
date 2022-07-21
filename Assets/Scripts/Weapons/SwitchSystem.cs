using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSystem
{
    public enum WeaponType 
    {
        Pistol,
        Riffle
    }

    private WeaponController _weaponSwitch;
    private List<WeaponSwitcher> _weaponList;

    public SwitchSystem(WeaponController _weapon)
    { 
        this._weaponSwitch = _weapon;
        _weaponList = new List<WeaponSwitcher>
        {
            new WeaponSwitcher
            {
                weapon = WeaponType.Pistol,
                activateWeapon = () => _weaponSwitch.SetWeaponData("Pistol")
            },
            new WeaponSwitcher
            {
                weapon = WeaponType.Riffle,
                activateWeapon = () => _weaponSwitch.SetWeaponData("Riffle")
            }
        };
    }

    //private void Start()
    //{
    //    _weaponController = GetComponent<WeaponController>();
    //}

    //public void Weapon(string weapon)
    //{
    //    switch (weapon)
    //    {
    //        case "Pistol":
    //            _weaponController.SetWeaponData("Pistol");
    //            break;
    //        case "Riffle":
    //            _weaponController.SetWeaponData("Riffle");
    //            break;
    //    }

    //}

    public List<WeaponSwitcher> GetWeaponsInList()
    {
        return _weaponList;
    }
    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        _weaponList[0].activateWeapon();
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        _weaponList[1].activateWeapon();
    //    }
    //}
    public class WeaponSwitcher
    {
        public WeaponType weapon;
        public Action activateWeapon;

        public Sprite GetSprite()
        {
            switch (weapon)
            {
                default:
                case WeaponType.Pistol:
                    return BasicSetUp.Instance.pistol;
                case WeaponType.Riffle:
                    return BasicSetUp.Instance.riffle;
            }
        }
    }
}
