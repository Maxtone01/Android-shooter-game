using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public int damage = 10;

    public void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Hit " + collision);
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.TryGetComponent<EnemyController>(out EnemyController enemyController))
        {
            enemyController.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
