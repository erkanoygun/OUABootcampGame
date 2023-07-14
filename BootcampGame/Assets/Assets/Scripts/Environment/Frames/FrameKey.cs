using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FrameKey : MonoBehaviour
{
    Collider[] objects;
    [SerializeField] float detectionRadius = 5f;
    [SerializeField] GameObject _playerGO;
    GameObject _canvasGO;
    PlayerController _playerControllerScr;

    [SerializeField] GameObject _keyGO;

    [SerializeField] private Image PortraitPieceImage;

    private bool _isHasPiece1 = false, _isHasPiece2 = false, _isHasPiece3 = false;
    void Start()
    {
        InvokeRepeating(nameof(ScanArea), 0, 0.5f);
        _playerControllerScr = _playerGO.GetComponent<PlayerController>();
        _canvasGO = transform.GetChild(2).gameObject;

    }


    void Update()
    {
        if (_isHasPiece1 && _isHasPiece2 && _isHasPiece3)
        {
            if(_keyGO != null)
            {
                if(!_keyGO.activeSelf)
                    _keyGO.SetActive(true);
            }
        }
    }



    private void ScanArea()
    {
        objects = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider item in objects)
        {
            if (item.gameObject.tag == "Player")
            {
                if (_playerControllerScr._isHasPieceImage1 && !_canvasGO.transform.GetChild(1).gameObject.activeSelf)
                {
                    _canvasGO.transform.GetChild(1).gameObject.SetActive(true);
                    _isHasPiece1 = true;
                    PortraitPieceImage.fillAmount -= 33;
                }
                if (_playerControllerScr._isHasPieceImage2 && !_canvasGO.transform.GetChild(2).gameObject.activeSelf)
                {
                    _canvasGO.transform.GetChild(2).gameObject.SetActive(true);
                    _isHasPiece2 = true;
                    PortraitPieceImage.fillAmount -= 33;
                }
                if (_playerControllerScr._isHasPieceImage2 && !_canvasGO.transform.GetChild(3).gameObject.activeSelf)
                {
                    _canvasGO.transform.GetChild(3).gameObject.SetActive(true);
                    _isHasPiece3 = true;
                    PortraitPieceImage.fillAmount -= 33;
                }
            }


        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
