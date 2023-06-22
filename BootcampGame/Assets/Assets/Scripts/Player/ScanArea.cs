using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanArea : MonoBehaviour
{
    PlayerController _playerControllerScr;

    private void Start() {
        _playerControllerScr = GetComponentInParent<PlayerController>();
    }


    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("takeItem")){
            if(!_playerControllerScr.isTakeItem){
                _playerControllerScr.targetBoxGO = other.gameObject;
            }
            _playerControllerScr.isGiveBox = true;
        }

        if(other.gameObject.CompareTag("itemSlot")){
            _playerControllerScr.itemSlot = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other) {

        if(other.gameObject.CompareTag("takeItem")){
            if(!_playerControllerScr.isTakeItem){
                _playerControllerScr.targetBoxGO = null;
            }
            //_playerControllerScr.targetBoxGO = null;
            _playerControllerScr.isGiveBox = false;
        }

        if(other.gameObject.CompareTag("itemSlot")){
            _playerControllerScr.itemSlot = null;
        }
    }
    
    
}
