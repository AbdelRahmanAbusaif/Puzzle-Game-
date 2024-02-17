using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHandiler : MonoBehaviour
{
    [SerializeField] private Transform bullet;
    [SerializeField] private Transform shootPosition;

    [SerializeField] private float speedBullet;
    [SerializeField] private float maxCountBullet;

    private PlayerMovement player;
    public float currentBullet;
    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        currentBullet = maxCountBullet;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && currentBullet != 0)
        {
            shoot();
            currentBullet--;
        }
    }
    private void shoot()
    {
        GameObject bulletShoot = Instantiate(bullet.gameObject, shootPosition.position, Quaternion.identity);

        Rigidbody2D rb = bulletShoot.gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sp = bulletShoot.GetComponent<SpriteRenderer>();

        if (rb != null && player.FaceRight != 0)
        {
            if (player.FaceRight != 1)
            {
                sp.flipX = true;
            }

            rb.AddForce(player.FaceRight * Vector2.right * speedBullet, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * speedBullet, ForceMode2D.Impulse);
        }

        StartCoroutine(destroyBullet(bulletShoot.gameObject));
    }

    private IEnumerator destroyBullet(GameObject Object)
    {
        yield return new WaitForSeconds(3);
        Destroy(Object);
    }
}
