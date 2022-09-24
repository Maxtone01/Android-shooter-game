using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float maxSpeed = 1.5f;
    public float rotationSpeed = 100;
    private Vector2 movementVector;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, movementVector, maxSpeed * Time.fixedDeltaTime);
    }
}
