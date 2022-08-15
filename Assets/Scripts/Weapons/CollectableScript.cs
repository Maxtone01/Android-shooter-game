using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public enum WeaponType
    {
        Riffle,
        Pistol,
    }

    public WeaponType weaponType;
    public int bulletsQuantity;
}
