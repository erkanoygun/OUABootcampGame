using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
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
        _audioSource.clip = _audioClips[0];
        _audioSource.Play();
    }

    public void PlayOneShotAnySound(int index){
        _audioSource.PlayOneShot(_audioClips[index]);
    }
}
