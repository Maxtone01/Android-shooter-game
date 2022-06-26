using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    PlayerScript _playerScript;

    public float speed;

    public void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreLayerCollision(_playerScript.gameObject.layer, gameObject.layer);
        }
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
