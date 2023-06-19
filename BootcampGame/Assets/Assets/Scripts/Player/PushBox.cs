using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    
    private BoxCollider boxCollider;
    private PlayerController _playerControllerScr;
    private GameObject _playerGO;
    private bool isChangeCollider = false;
    private bool _isPressQ = false;

    public bool isTriggerBigBox = false;
    public float range = 5.0f;



    void Start()
    {
        _playerGO = GameObject.Find("Player");

        boxCollider = GetComponent<BoxCollider>();
        _playerControllerScr = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        _isPressQ = Input.GetKeyDown(KeyCode.Q);
    }

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (!_playerControllerScr.isTakeItem)
            {
                if (hit.collider.tag == "BigBox")
                {
                    if (!isTriggerBigBox)
                    {
                        isTriggerBigBox = true;
                    }

                    if (_isPressQ)
                    {
                        /*Transform parentTransform = hit.collider.gameObject.transform.parent;
                        parentTransform.position = Vector3.Lerp(parentTransform.position, transform.position, 10.0f * Time.deltaTime);*/
                        pushingBox(hit);
                    }

                    if (!boxCollider.enabled)
                    {
                        boxCollider.enabled = true;
                    }
                    if (!_playerControllerScr.isPushingBox)
                    {
                        _playerControllerScr.isPushingBox = true;
                    }
                }
                else
                {
                    if (isTriggerBigBox)
                    {
                        isTriggerBigBox = false;
                    }
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
            if (isTriggerBigBox)
            {
                isTriggerBigBox = false;
            }

        }
    }

    void pushingBox(RaycastHit hit)
    {
        Transform playerBodyTrns = _playerGO.transform.GetChild(0);
        Vector3 pushDirection = -playerBodyTrns.forward;
        Rigidbody rigidbody = hit.collider.transform.parent.GetComponent<Rigidbody>();
        rigidbody.AddForce(pushDirection * 4.0f, ForceMode.VelocityChange);
    }
}
