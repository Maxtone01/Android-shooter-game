using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSystem: MonoBehaviour
{
    public enum WeaponType 
    {
        Pistol,
        Riffle
    }

    private WeaponController _weaponSwitch;
    private List<WeaponSwitcher> _weaponList;

    public static SwitchSystem Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        _weaponSwitch = GetComponent<WeaponController>();
    }

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

    public void Weapon(string weapon)
    {
        switch (weapon)
        {
            case "Pistol":
                _weaponSwitch.SetWeaponData("Pistol");
                break;
            case "Riffle":
                if (SimpleInventory.Instance.inventory.Contains("Pistol"))
                    _weaponSwitch.SetWeaponData("Riffle");
                else
                    print("Not in inventory");
                break;
        }
    }

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
