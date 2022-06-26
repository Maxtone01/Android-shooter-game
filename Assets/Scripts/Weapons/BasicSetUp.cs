using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSetUp : MonoBehaviour
{
    [SerializeField]
    private WeaponController _controller;
    private WeaponSwitchSystem _weaponSystem;

    void Start()
    {
        _weaponSystem = new WeaponSwitchSystem(_controller);
    }
    void Update()
    {
        _weaponSystem.Update();
    }
}
