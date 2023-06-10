using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public float range = 5.0f;

    private BoxCollider boxCollider;
    private PlayerController _playerControllerScr;

    bool isChangeCollider = false;


    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        _playerControllerScr = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (!_playerControllerScr.isTakeBox)
            {
                if (hit.collider.tag == "BigBox")
                {
                    if (!boxCollider.enabled)
                    {
                        boxCollider.enabled = true;
                    }
                    _playerControllerScr.isPushingBox = true;

                }
            }
            isChangeCollider = true;

        }
        else
        {
            if (isChangeCollider)
            {
                boxCollider.enabled = false;
                _playerControllerScr.isPushingBox = false;
                isChangeCollider = false;
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
