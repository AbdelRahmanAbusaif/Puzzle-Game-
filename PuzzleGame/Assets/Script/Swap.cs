using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    [Header("Swap")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Square;
    private Vector2 vector2;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            vector2 = player.transform.position;
            player.transform.position = Square.transform.position;
            Square.transform.position = vector2;
        }
    }
}