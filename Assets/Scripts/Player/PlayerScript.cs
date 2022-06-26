using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private WeaponController weaponController;
    public Stack<string> inventory;
    internal Rigidbody2D rb2d;
    internal Animator animator;
    internal SpriteRenderer[] spriteRenderer;
    private Sprite _pistol, _riffle;
    
    void Start()
    {
        inventory = new Stack<string>();
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
            spriteRenderer[1].sprite = weapon;
            //print(spriteRenderer[1].sprite.name);
            //print("Sprite: " + spriteRenderer[1].sprite);
            //print("Colected: " + itemType);
            if (!inventory.Contains(itemType))
            {
                inventory.Push(itemType);
            }
            
        }
    }
}
