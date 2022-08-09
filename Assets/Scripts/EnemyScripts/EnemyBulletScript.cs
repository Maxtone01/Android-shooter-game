using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private readonly EnemyController _enemy;
    public float speed = 10;
    public float damage = 5;
    public float maxDistance = 10;

    private Vector2 _startPosition;
    private float _conquartedDistance = 0;
    private Rigidbody2D _rb2d;

    private void Start()
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreLayerCollision(_enemy.gameObject.layer, gameObject.layer);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}
