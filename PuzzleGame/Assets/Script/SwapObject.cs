using UnityEngine;
public class SwapObject : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject PotalOut;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Square"))
        {
            player.transform.position = PotalOut.transform.position;
        }
    }
}