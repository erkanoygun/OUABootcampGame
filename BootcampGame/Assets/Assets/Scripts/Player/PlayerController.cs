using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform chestPointTRN;
    public GameObject chestPointGO;
    GameObject targetBoxGO;

    PlayerMoveController playerMoveControllerSrc;


    public bool isTakeBox = false;
    public bool isPushingBox = false;
    bool isGiveBox = false;
    bool isPressE = false;


    void Start()
    {
        chestPointTRN = chestPointGO.transform;
        playerMoveControllerSrc = GetComponent<PlayerMoveController>();
    }

    
    void Update()
    {
        isPressE = Input.GetKeyDown(KeyCode.E);
        //Debug.Log(playerMoveControllerSrc.isRaning);

        if (isPressE && isGiveBox)
        {
            //Debug.Log(playerMoveControllerSrc.isRaning);
            if (!playerMoveControllerSrc.isRaning)
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
            

        }

        if (isTakeBox)
        {
            targetBoxGO.transform.position = chestPointTRN.position;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            isGiveBox = true;
            targetBoxGO = other.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            isGiveBox = false;
        }
    }
    
}
