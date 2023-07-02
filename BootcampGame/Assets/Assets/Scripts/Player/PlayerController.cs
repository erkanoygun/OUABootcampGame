using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform chestPointTRN;
    [SerializeField] private GameObject chestPointGO;
    private SoundController _soundController;

    public GameObject targetBoxGO;

    PlayerMoveController playerMoveControllerSrc;


    public bool isTakeItem = false;
    public bool isPushingBox = false;
    public bool isGiveBox = false;
    bool isPressE = false;
    public Transform itemSlot;

    public bool _isHasKey = false;
    private bool _isHasPieceImage1 = false, _isHasPieceImage2 = false, _isHasPieceImage3 = false;


    void Start()
    {
        _soundController = gameObject.transform.GetChild(0).gameObject.GetComponent<SoundController>();
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

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PieceImage")){
            if(other.gameObject.name == "PieceImage1"){
                _isHasPieceImage1 = true;
            }
            else if(other.gameObject.name == "PieceImage2"){
                _isHasPieceImage2 = true;
            }
            else if(other.gameObject.name == "PieceImage3"){
                _isHasPieceImage3 = true;
            }
            _soundController.PlayOneShotAnySound(1);
            Destroy(other.gameObject);
        }
    }

}