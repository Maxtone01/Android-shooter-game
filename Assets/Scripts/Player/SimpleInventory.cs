using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInventory : MonoBehaviour
{
    public List<CollectableScript.WeaponType> inventory;
    public static SimpleInventory Instance { get; private set; }

    public void Awake()
    {
        inventory = new List<CollectableScript.WeaponType>
        {
            CollectableScript.WeaponType.Pistol,
        };
        Instance = this;
    }

    public void AddToInventory(Collider2D collision)
    {
        CollectableScript.WeaponType itemType = collision.gameObject.GetComponent<CollectableScript>().weaponType;
        int bulletsQuantity = collision.gameObject.GetComponent<CollectableScript>().bulletsQuantity;
        //Sprite weapon = Resources.Load(itemType, typeof(Sprite)) as Sprite;
        if (!inventory.Contains(itemType))
        {
            inventory.Add(itemType);
            UIWeaponSwap.Instance.ActivateWeapon(itemType);
        }
        else if(collision.gameObject.GetComponent<CollectableScript>().weaponType == CollectableScript.WeaponType.Pistol)
        {
            WeaponController.Instance.SetSupplyQuantity(itemType, bulletsQuantity);
        }
        else if (collision.gameObject.GetComponent<CollectableScript>().weaponType == CollectableScript.WeaponType.Riffle)
        {
            WeaponController.Instance.SetSupplyQuantity(itemType, bulletsQuantity);
        }
        Destroy(collision.gameObject);
    }
}
