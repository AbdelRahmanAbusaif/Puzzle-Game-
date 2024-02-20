using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
    }
    public void Play() => StartCoroutine(Wait());
    public void Quit() => Application.Quit();

    IEnumerator Wait()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        anim.SetTrigger("Start");
    }
}
