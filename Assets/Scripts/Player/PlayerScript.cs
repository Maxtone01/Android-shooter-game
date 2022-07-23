using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private WeaponController weaponController;
    public List<string> inventory;
    internal Rigidbody2D rb2d;
    internal Animator animator;
    internal SpriteRenderer[] spriteRenderer;
    private Sprite _pistol, _riffle;
    
    void Start()
    {
        //Application.targetFrameRate = 60;
        inventory = new List<string>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        _pistol = Resources.Load<Sprite>("Pistol");
        _riffle = Resources.Load<Sprite>("Riffle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            string itemType = collision.gameObject.GetComponent<CollectableScript>().itemType;
            Sprite weapon = Resources.Load(itemType, typeof(Sprite)) as Sprite;
            if (!inventory.Contains(itemType))
            {
                inventory.Add(itemType);
            }
            Destroy(collision.gameObject);

        }
    }
}
