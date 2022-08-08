using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSetUp : MonoBehaviour
{
    [SerializeField]
    private WeaponController _controller;
    [SerializeField]
    private HotkeyWeapons _hotkeyWeapons;
    private SwitchSystem _weaponSystem;

    public static BasicSetUp Instance { get; private set; }
    public Sprite pistol;
    public Sprite riffle;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _weaponSystem = new SwitchSystem(_controller);
        _hotkeyWeapons.SetWeaponSytem(_weaponSystem);
        
    }
}
