using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform chestPointTRN;
    [SerializeField] private GameObject chestPointGO;
    GameObject targetBoxGO;

    PlayerMoveController playerMoveControllerSrc;


    public bool isTakeItem = false;
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

        if (isPressE && isGiveBox)
        {
            if (!playerMoveControllerSrc.isRaning)
            {
                if (!isTakeItem)
                {
                    isTakeItem = true;
                }
                else
                {
                    isTakeItem = false;
                }
            }
            

        }

        if (isTakeItem)
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
