using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool IsOpen = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Square") || collision.gameObject.CompareTag("Player"))
        {
            IsOpen = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.03f, transform.position.z);
            print("IsOpen " + IsOpen);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Square") && IsOpen)
        {
            IsOpen = false;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.03f, transform.position.z);
            print("IsOpen " + IsOpen);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Square") && !IsOpen)
        {
            IsOpen = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.03f, transform.position.z);
            print("IsOpen " + IsOpen);
        }
    }
}