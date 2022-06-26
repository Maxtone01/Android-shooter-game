using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWeaponSwap : MonoBehaviour
{
    private Transform _weaponSlot;
    private void Awake()
    {
        _weaponSlot = transform.Find("weaponSlot");
        _weaponSlot.gameObject.SetActive(false);
    }
}
