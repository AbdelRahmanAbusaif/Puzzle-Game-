using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    [Header("Swap")]
    [SerializeField] private GameObject player;

    private Vector2 vector2;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            vector2 = player.transform.position;
            player.transform.position = transform.position;
            transform.position = vector2;
        }
    }
}