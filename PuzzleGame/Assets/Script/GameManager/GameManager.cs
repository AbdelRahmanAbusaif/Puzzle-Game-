using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.Log("Duplicate GameManager ");
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
            Restat();
    }
    public void EndGame()
    {
        Debug.Log("EndGame");
        FindObjectOfType<PlayerMovement>().enabled = false;
        Invoke("Restat", 1f);

    }
    public void Restat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}