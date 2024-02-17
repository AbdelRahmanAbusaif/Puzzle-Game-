using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    [Header("Swap")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject EffectTrasition;

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
            RunParticle(transform, player.transform);
        }
    }
    private void RunParticle(Transform firstPlace, Transform lastPlace)
    {
        GameObject ins1 = Instantiate(EffectTrasition, firstPlace.position, Quaternion.identity);
        GameObject ins2 = Instantiate(EffectTrasition, lastPlace.position, Quaternion.identity);

    }
}