using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float detectionRadius = 5f;

    private Animator animator;

    bool isWalk = true;

    bool _goToLeft = true;

    Collider[] objects;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        InvokeRepeating(nameof(ScanArea), 0, 0.5f);
    }

    void Update()
    {
        if (isWalk)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Idle", false);
            float moveDistance = speed * Time.deltaTime;

            if(_goToLeft){
                transform.Translate(Vector3.forward * moveDistance);
                transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                if(transform.localPosition.z < -30)
                    _goToLeft = false;
            }
            else{
                transform.Translate(Vector3.forward * moveDistance);
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                if(transform.localPosition.z >= 30)
                    _goToLeft = true;
            }
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
            transform.Translate(Vector3.zero);
        }

    }

    private void ScanArea()
    {
        objects = Physics.OverlapSphere(transform.position, detectionRadius);
        isWalk = true;

        foreach (Collider item in objects)
        {
            if (item.gameObject.tag == "Player")
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
