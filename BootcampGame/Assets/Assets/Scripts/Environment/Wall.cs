using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float pushBackForce = 80f;
    public bool testt = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {


        /*if (collision.gameObject.CompareTag("BigBox"))
        {
            if (testt)
            {
                Vector3 force = collision.contacts[0].normal * pushBackForce;

                Rigidbody wallRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                if (wallRigidbody != null)
                {
                    wallRigidbody.AddForce(force);
                }
            }

        }*/

    }
}
