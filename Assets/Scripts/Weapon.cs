using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    public enum WeaponType
    { 
        Riffle,
        Pistol,

    }
    public enum ClipType
    { 
        lightClip,
        mediumClip,
        heavyClip
    }

    public GameObject weaponPrefab;
    public int damage;
    public int bulletsQuantity;
    public WeaponType weaponType;
    public ClipType clipType;
}
