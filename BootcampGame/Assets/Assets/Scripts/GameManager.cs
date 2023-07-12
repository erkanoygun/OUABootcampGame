using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject _playerGO;
    PlayerController _playerControllerScr;

    [SerializeField] private GameObject _keyImage;
    void Start()
    {
        _playerControllerScr = _playerGO.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerControllerScr._isHasKey)
        {
            _keyImage.SetActive(true);
        }
    }
}
