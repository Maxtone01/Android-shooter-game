using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public List<Transform> guns;
    public GameObject bulletPrefab;
    public float reloadDelay;
    public float currentDelay = 0;

    private bool canShoot = true;
    private Collider2D[] enemyColliders;

    private void Awake()
    {
        enemyColliders = GetComponentsInChildren<Collider2D>();
    }

    private void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }
    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var gun in guns)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = gun.position;
                bullet.transform.localRotation = gun.rotation;
                bullet.GetComponent<EnemyBulletScript>().Initialize();
                foreach (var collider in enemyColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }
        }
    }
}
