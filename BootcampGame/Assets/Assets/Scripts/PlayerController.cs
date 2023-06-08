using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform chestPointTRN;
    public GameObject chestPointGO;
    GameObject targetBoxGO;

    public bool isTakeBox = false;
    public bool isPushingBox = false;
    bool isGiveBox = false;
    bool isPushBox = false;
    bool isPressE = false;

    void Start()
    {
        chestPointTRN = chestPointGO.transform;
    }

    
    void Update()
    {
        isPressE = Input.GetKeyDown(KeyCode.E);

        if (isPressE && isGiveBox)
        {
            
            if (!isTakeBox)
            {
                isTakeBox = true;
            }
            else
            {
                isTakeBox = false;
            }
        }
        else if(isPressE && isPushBox)
        {
            if (!isPushingBox)
            {
                isPushingBox = true;
            }
            else
            {
                isPushingBox = false;
            }
        }

        if (isTakeBox)
        {
            targetBoxGO.transform.position = chestPointTRN.position;
        }

    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            isGiveBox = true;
            targetBoxGO = other.gameObject.transform.parent.gameObject;
        }
        if (other.gameObject.CompareTag("BigBox"))
        {
            isPushBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            isGiveBox = false;
            isPushBox = false;
        }
    }
    
}
