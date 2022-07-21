using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISwap : MonoBehaviour, IPointerClickHandler
{
    private SwitchSystem.WeaponSwitcher _weaponSwitcher;

    public void SetWeaponType(SwitchSystem.WeaponSwitcher _weaponSwitcher)
    {
        this._weaponSwitcher = _weaponSwitcher;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        _weaponSwitcher.activateWeapon();
    }
}
