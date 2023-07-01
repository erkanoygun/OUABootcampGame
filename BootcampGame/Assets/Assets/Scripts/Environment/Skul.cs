using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skul : MonoBehaviour
{
    Light _light;
    PlayerController _playerControllerSrc;

    [SerializeField] private GameObject _cupboardRightDoor, _cupboardLeftDoor;
    void Start()
    {
        _playerControllerSrc = GameObject.Find("Player").GetComponent<PlayerController>();
        _light = transform.GetChild(1).gameObject.GetComponent<Light>();
    }

    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "itemSlot"){
            if(other.gameObject.transform.parent.gameObject.transform.parent.name == "Cupboard"){
                if(!_playerControllerSrc.isTakeItem){
                    _light.enabled = true;
                    SetTriggerDoorAnim(_cupboardRightDoor);
                    SetTriggerDoorAnim(_cupboardLeftDoor);
                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.name == "itemSlot"){
            if(other.gameObject.transform.parent.gameObject.transform.parent.name == "Cupboard"){
                _light.enabled = false;
            }
        }
    }

    void SetTriggerDoorAnim(GameObject go){
        go.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Open");
    }

    
}
