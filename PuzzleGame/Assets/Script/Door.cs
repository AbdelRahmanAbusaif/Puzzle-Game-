using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject game;
    private Key key;
    Vector3 oldPosition;
    private void Start()
    {
        oldPosition = transform.position;
        key = game.GetComponent<Key>();
    }

    private void Update()
    {
        if (key.IsOpen)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        }
        else
        {
            transform.position = oldPosition;
        }
    }
}
