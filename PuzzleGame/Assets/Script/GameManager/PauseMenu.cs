using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 0;
            this.gameObject.SetActive(true);
        }
    }
    public void Resume()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
        anim.SetTrigger("Start");
    }
}
