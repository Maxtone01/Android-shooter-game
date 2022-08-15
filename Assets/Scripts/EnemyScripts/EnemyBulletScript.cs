using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed = 10;
    public int damage = 5;
    public float maxDistance = 10;

    private Vector2 _startPosition;
    private float _conquartedDistance = 0;
    internal Rigidbody2D _rb2d;
    private EnemyController _enemyController;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        _startPosition = transform.position;
        _rb2d.velocity = transform.right * speed;
    }

    private void Update()
    {
        _conquartedDistance = Vector2.Distance(transform.position, _startPosition);
        if (_conquartedDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreLayerCollision(_enemyController.gameObject.layer, gameObject.layer);
        }
        if (collision.gameObject.TryGetComponent<PlayerScript>(out PlayerScript playerScript))
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}
