using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingItems : MonoBehaviour
{
    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("takeItem"))
        {
            _rb.isKinematic = true;
        }
        else
        {
            _rb.isKinematic = false;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("Player") && !_rb.isKinematic)
        {
            _rb.isKinematic = false;
        }*/
    }
}
