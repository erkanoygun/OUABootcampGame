using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float detectionRadius = 5f;

    Collider[] objects;

    private void Start()
    {
        InvokeRepeating(nameof(ScanArea), 0, 0.5f);
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDistance);
    }

    private void ScanArea()
    {
        objects = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach(Collider item in objects)
        {
            if(item.gameObject.tag == "Player")
            {
                Debug.Log("Player Dedected");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
