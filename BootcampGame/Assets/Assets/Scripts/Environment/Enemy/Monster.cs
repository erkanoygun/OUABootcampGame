using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float detectionRadius = 5f;

    private Animator animator;

    bool isWalk = true;

    Collider[] objects;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        InvokeRepeating(nameof(ScanArea), 0, 0.5f);
    }

    void Update()
    {
        if(isWalk){
            animator.SetBool("Walk", true);
            animator.SetBool("Idle", false);
            float moveDistance = speed * Time.deltaTime;
            transform.Translate(Vector3.forward * moveDistance);
        }else{
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
            transform.Translate(Vector3.zero);
        }
        
    }

    private void ScanArea()
    {
        objects = Physics.OverlapSphere(transform.position, detectionRadius);
        isWalk = true;

        foreach(Collider item in objects)
        {
            if(item.gameObject.tag == "Player")
            {
                isWalk = false;
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
