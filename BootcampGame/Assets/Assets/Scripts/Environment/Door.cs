using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    AudioSource _audioSource;
    [SerializeField] private GameObject _doorBody;
    [SerializeField] private AudioClip _lockedDoorClip;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void playSound(){
        _audioSource.PlayOneShot(_lockedDoorClip);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            if(other.gameObject.GetComponent<PlayerController>()._isHasKey){
                _doorBody.GetComponent<Animator>().SetTrigger("OpenDoor");
                StartCoroutine(SetEnabledCollider());
            }
            else{
                playSound();
            }

        }
    }

    IEnumerator SetEnabledCollider()
    {
        yield return new WaitForSeconds(1.3f);
        gameObject.GetComponent<BoxCollider>().enabled = false;

    }
}
