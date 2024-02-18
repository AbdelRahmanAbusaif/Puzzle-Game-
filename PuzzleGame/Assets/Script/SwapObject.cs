using System.Collections;
using UnityEngine;
public class SwapObject : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject PotalOut;
    [SerializeField] private GameObject EffectTrasition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RunParticle(player.transform, PotalOut.transform);
            player.transform.position = PotalOut.transform.position;
        }
    }

    private void RunParticle(Transform firstPlace, Transform lastPlace)
    {
        GameObject ins1 = Instantiate(EffectTrasition, firstPlace.position, Quaternion.identity);
        GameObject ins2 = Instantiate(EffectTrasition, lastPlace.position, Quaternion.identity);

        StartCoroutine(DeleteEffect(ins1, ins2));

    }

    IEnumerator DeleteEffect(GameObject gameObject, GameObject gameObject1)
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
        Destroy(gameObject1);
    }
}