using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingItems : MonoBehaviour
{
    Rigidbody _rb;

    public float pushBackForce = 10f;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && _rb.isKinematic)
        {
            _rb.isKinematic = false;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_rb.isKinematic)
        {
            _rb.isKinematic = true;
        }
    }
}
