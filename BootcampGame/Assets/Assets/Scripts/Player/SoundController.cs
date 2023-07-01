using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip walkClip;
    private PlayerMoveController _playerMoveControllerScr;
    void Start()
    {
        _playerMoveControllerScr = GetComponent<PlayerMoveController>();
        _audioSource = GetComponentInParent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    void PlayWalkSound(){
        _audioSource.clip = walkClip;
        _audioSource.Play();
    }
}
