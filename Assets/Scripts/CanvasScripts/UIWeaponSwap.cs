using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIWeaponSwap : MonoBehaviour, IPointerClickHandler
{
    private SwitchSystem.WeaponSwitcher _weaponSwitcher;
    //public RectTransform pistolButton, riffleButton;

    //private void Start()
    //{
    //    pistolButton = GetComponent<RectTransform>();
    //    riffleButton = GetComponent<RectTransform>();
    //}

    public void SetWeaponType(SwitchSystem.WeaponSwitcher _weaponSwitcher)
    {
        this._weaponSwitcher = _weaponSwitcher;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(weaponClicked = eventData.pointerCurrentRaycast.gameObject.name);
        _weaponSwitcher.activateWeapon();
        //_switchSystem.Weapon(weaponClicked);
    }

}
