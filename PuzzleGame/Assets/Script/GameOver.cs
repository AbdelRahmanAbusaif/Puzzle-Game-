using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public void Restat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.collider.tag == "Player")
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
