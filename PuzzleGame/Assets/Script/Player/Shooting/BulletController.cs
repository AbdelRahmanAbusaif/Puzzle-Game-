using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyParicle;

    private SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Physics2D.IgnoreLayerCollision(7, 3);
        Physics2D.IgnoreLayerCollision(7, 7);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Debug.Log("ParticleDestroy");

            particlePlay();
            sp.enabled = false;
            StartCoroutine(waitToDestroy());
        }
    }
    private void particlePlay()
    {
        if (destroyParicle != null)
        {
            destroyParicle.Play();
        }
        else
        {
            Debug.Log("Particle  is Null");
        }
    }
    private IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}