using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private WeaponController weaponController;
    internal Rigidbody2D rb2d;
    internal Animator animator;
    internal SpriteRenderer[] spriteRenderer;
    private Sprite _pistol, _riffle;

    public static PlayerScript Instance { get; private set; }

    void Start()
    {
        Instance = this;
        //Application.targetFrameRate = 60;
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
            SimpleInventory.Instance.AddToInventory(collision);
        }
    }
}
