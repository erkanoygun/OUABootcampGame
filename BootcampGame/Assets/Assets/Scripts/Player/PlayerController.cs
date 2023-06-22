using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform chestPointTRN;
    [SerializeField] private GameObject chestPointGO;

    public GameObject targetBoxGO;

    PlayerMoveController playerMoveControllerSrc;


    public bool isTakeItem = false;
    public bool isPushingBox = false;
    public bool isGiveBox = false;
    bool isPressE = false;

    public Transform itemSlot;


    void Start()
    {
        chestPointTRN = chestPointGO.transform;
        playerMoveControllerSrc = GetComponent<PlayerMoveController>();

    }

    void Update()
    {
        isPressE = Input.GetKeyDown(KeyCode.E);

        if (isPressE && itemSlot != null && isTakeItem)
        {
            targetBoxGO.GetComponent<BoxCollider>().isTrigger = true;
            targetBoxGO.GetComponent<Rigidbody>().isKinematic = true;
            targetBoxGO.transform.position = itemSlot.position;
            isTakeItem = false;
        }

        else if (isPressE && targetBoxGO != null && isGiveBox && !isTakeItem)
        {
            isTakeItem = true;
        }

        else if (isPressE && isTakeItem)
        {
            targetBoxGO.GetComponent<BoxCollider>().isTrigger = false;
            targetBoxGO.GetComponent<Rigidbody>().isKinematic = false;
            isTakeItem = false;
        }

        if (isTakeItem)
        {
            targetBoxGO.GetComponent<BoxCollider>().isTrigger = true;
            targetBoxGO.GetComponent<Rigidbody>().isKinematic = false;
            targetBoxGO.transform.position = chestPointTRN.position;
        }
    }


}