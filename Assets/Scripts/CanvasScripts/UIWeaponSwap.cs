using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIWeaponSwap : MonoBehaviour, IPointerClickHandler
{
    private Transform _weaponSlot;

    public static UIWeaponSwap Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        _weaponSlot = transform.Find("WeaponSlots");
    }

    public void ActivateWeapon(string weapon)
    {
        switch (weapon) 
        {
            case "Pistol":
                if(!_weaponSlot.Find("Pistol").gameObject.activeSelf)
                    _weaponSlot.Find("Pistol").gameObject.SetActive(true);
                break;
            case "Riffle":
                if (!_weaponSlot.Find("Riffle").gameObject.activeSelf)
                    _weaponSlot.Find("Riffle").gameObject.SetActive(true);
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string weapon = eventData.pointerCurrentRaycast.gameObject.name;
        SwitchSystem.Instance.Weapon(weapon);
    }

}
