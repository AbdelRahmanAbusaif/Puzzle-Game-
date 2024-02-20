using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIn : MonoBehaviour
{
    [SerializeField] private ParticleSystem Heart;
    private AudioManager am;
    private PlayerMovement Player;

    public Animator anim;

    private void Start()
    {
        am = FindAnyObjectByType<AudioManager>();
        Player = FindAnyObjectByType<PlayerMovement>().GetComponent<PlayerMovement>();
        anim = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
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
        Player.enabled = false;
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(1);
        anim.SetTrigger("End");
        yield return new WaitForSeconds(2);
        Heart.Pause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Player.enabled = true;
        anim.SetTrigger("Start");
    }
}
