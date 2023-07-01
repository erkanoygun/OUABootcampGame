using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip walkClip;
    void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
    }

    void PlayWalkStep(){
        _audioSource.clip = walkClip;
        _audioSource.Play();
    }
}
