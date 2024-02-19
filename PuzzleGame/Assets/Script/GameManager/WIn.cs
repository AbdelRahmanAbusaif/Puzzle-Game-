using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIn : MonoBehaviour
{
    [SerializeField] private ParticleSystem Heart;
    private AudioManager am;
    private void Start()
    {
        am = FindAnyObjectByType<AudioManager>();
    }
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.collider.tag == "Player")
        {
            Heart.Play();
            am.PlayClip(am.WinSound);
            StartCoroutine(WinObject());
        }
    }
    private IEnumerator WinObject()
    {
        yield return new WaitForSeconds(1);
        Heart.Pause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
