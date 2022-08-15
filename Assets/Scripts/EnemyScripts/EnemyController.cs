using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    internal Rigidbody2D rb2d;
    internal SpriteRenderer spriteRenderer;
    internal Animator animator;
    public Gun[] guns;
    public EnemyMover enemyMover;
    public AimGun aimGun;
    public int health;

    public int currentHealth;
    public HealthBar healthBar;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (enemyMover == null)
            enemyMover = GetComponentInChildren<EnemyMover>();
        if (aimGun == null)
            aimGun = GetComponentInChildren<AimGun>();
        if (guns == null || guns.Length == 0)
        {
            guns = GetComponentsInChildren<Gun>();
        }
        rb2d = GetComponent<Rigidbody2D>();

        this.currentHealth = health;

        healthBar.SetMaxHealth(health);
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        //enemyMover.Move(movementVector);
        //animator.Play("Enemy00Run");
        if (movementVector.x > 1)
            spriteRenderer.flipX = false;
        else if (movementVector.y < -1)
            spriteRenderer.flipX = true;
    }

    public void HandleShoot()
    {
        foreach (var gun in guns)
        {
            gun.Shoot();
        }
    }

    public void HandleGunAim(Vector2 pointerPosition)
    {
        aimGun.Aim(pointerPosition);
    }

    public void TakeDamage(int damage)
    {
        this.currentHealth -= damage;
        if (this.currentHealth == 0)
        { 
            Destroy(gameObject);
        }
        healthBar.SetHealth(this.currentHealth);
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        TakeDamage();
    //    }
    //}
}
