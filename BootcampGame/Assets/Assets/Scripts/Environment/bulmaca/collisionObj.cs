using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionObj : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("t" + collision.gameObject.name);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("c" + collision.gameObject.name);
    }
}
