using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInventory : MonoBehaviour
{
    public List<string> inventory;
    public static SimpleInventory Instance { get; private set; }

    public void Awake()
    {
        inventory = new List<string>
        {
            "Pistol"
        };
        Instance = this;
    }

    public void AddToInventory(Collider2D collision)
    {
        string itemType = collision.gameObject.GetComponent<CollectableScript>().itemType;
        Sprite weapon = Resources.Load(itemType, typeof(Sprite)) as Sprite;
        if (!inventory.Contains(itemType))
        {
            inventory.Add(itemType);
            UIWeaponSwap.Instance.ActivateWeapon(itemType);
        }
        Destroy(collision.gameObject);
    }
}
