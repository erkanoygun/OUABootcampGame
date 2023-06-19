using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemPlacement : MonoBehaviour
{
    bool itemAround = false;
    GameObject itemGO = null;

    private bool _isHasItem = false;

    [SerializeField] private GameObject itemPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && itemAround && !_isHasItem)
        {
            if (itemGO != null)
            {
                itemGO.transform.position = itemPoint.transform.position;
                _isHasItem = true;
            }
        }
        else
        {
            _isHasItem = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            itemGO = other.gameObject.transform.parent.gameObject;
            itemAround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            itemAround = false;
        }
    }


    
}
