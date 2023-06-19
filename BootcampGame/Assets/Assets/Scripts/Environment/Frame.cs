using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    Collider[] objects;

    [SerializeField] float detectionRadius = 5f;

    private Vector3 initialPosition;
    private bool isMoving = false;

    Transform childTransform;
    Transform playerTransform;

    float moveStep = 0.008f;

    void Start()
    {
        childTransform = transform.GetChild(0);
        initialPosition = childTransform.localPosition;
        InvokeRepeating(nameof(ScanArea), 0, 0.5f);
    }

    void Update()
    {
        if (isMoving)
        {
            childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, new Vector3(0.30f, childTransform.localPosition.y, childTransform.localPosition.z), moveStep);
            childTransform.localRotation = Quaternion.RotateTowards(childTransform.localRotation, Quaternion.Euler(35f, 90.0f, 0.0f), Time.deltaTime * 45f);
        }
        else
        {
            childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, new Vector3(0.0f, childTransform.localPosition.y, childTransform.localPosition.z), moveStep);
            childTransform.localRotation = Quaternion.RotateTowards(childTransform.localRotation, Quaternion.Euler(0.0f, 90.0f, 0.0f), Time.deltaTime * 75f);
        }
    }

    private void ScanArea()
    {
        objects = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider item in objects)
        {
            if (item.gameObject.tag == "Player" && !isMoving)
            {
                playerTransform = item.gameObject.transform;
                isMoving = true;
            }
            if (item.gameObject.tag != "Player" && isMoving)
            {
                isMoving = false;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}






