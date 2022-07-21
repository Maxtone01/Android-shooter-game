using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotkeyWeapons : MonoBehaviour
{
    private Transform _weaponSlot;
    private SwitchSystem _switchSystem;

    private void Awake()
    {
        _weaponSlot = transform.Find("WeaponSlots");
        _weaponSlot.gameObject.SetActive(false);
    }

    public void SetWeaponSytem(SwitchSystem _switchSystem)
    { 
        this._switchSystem = _switchSystem;
        WeaponSwitcher();
    }

    private void WeaponSwitcher() 
    {
        List<SwitchSystem.WeaponSwitcher> _weaponList = _switchSystem.GetWeaponsInList();
        for (int i = 0; i < _weaponList.Count; i++)
        {
            SwitchSystem.WeaponSwitcher weaponSwitcher = _weaponList[i];
            Transform weaponSlotTransform = Instantiate(_weaponSlot, transform);
            weaponSlotTransform.gameObject.SetActive(true);
            RectTransform weaponSlotRectTransform = weaponSlotTransform.GetComponent<RectTransform>();
            weaponSlotRectTransform.anchoredPosition = new Vector2(429f * i, -304f);
            weaponSlotTransform.Find("Weapon").GetComponent<Image>().sprite = weaponSwitcher.GetSprite();
            weaponSlotTransform.GetComponent<UIWeaponSwap>().SetWeaponType(weaponSwitcher);
        }
    }
}
