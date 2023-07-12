using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wooden_Box : MonoBehaviour
{

    public bool isOpen = false;
    GameObject _childGO;
    Animator _animator;
    void Start()
    {
        _childGO = gameObject.transform.GetChild(0).gameObject;
        _animator = _childGO.GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            if(isOpen){
                _animator.SetTrigger("Open");
            }
            else{
                Debug.Log("Klickedddd!!!!");
            }
        }
    }
}
