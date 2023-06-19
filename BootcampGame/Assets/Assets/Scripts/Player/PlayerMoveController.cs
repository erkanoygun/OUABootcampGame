using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Animator animator;

    [Header("Player Move Variable")]
    public bool isRaning;
    public float moveSpeed = 5f;
    public float rotationSpeed = 7f;

    private Quaternion targetRotation;
    private bool isRotating = false;

    public float jumpForce = 5f;
    private bool isJumping = false;
    private Rigidbody rb;

    
    private PlayerController _playerControllerScr;
    private PushBox _pushBoxScr;

    Transform playerBodyTrans;

    bool _isPressW = false;
    bool _isPressA = false;
    bool _isPressS = false;
    bool _isPressD = false;
    bool _isPressQ = false;


    void Start()
    {
        _pushBoxScr = GetComponentInChildren<PushBox>();

        animator = GetComponentInChildren<Animator>();
        playerBodyTrans = transform.GetChild(0);
        targetRotation = playerBodyTrans.localRotation;
        rb = GetComponent<Rigidbody>();

        _playerControllerScr = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (isJumping)
        {
            if(isCheckGround() <= 0.085f)
            {
                isJumping = false;
            }
        }

        keyPushPress();

    }

    private void FixedUpdate()
    {
        if (_isPressD)
        {
            playerMove(Vector3.forward, 0f);
        }
        else if (_isPressA)
        {
            playerMove(Vector3.back, 180f);
        }

        else if (_isPressS)
        {
            playerMove(Vector3.right, 90f);
        }
        else if (_isPressW)
        {
            playerMove(Vector3.left, -90f);
        }
        else if (_isPressQ && _pushBoxScr.isTriggerBigBox && rb.velocity.magnitude <= 0.5)
        {
            animator.SetTrigger("pull");
            Vector3 pushDirection = -playerBodyTrans.forward;
            rb.AddForce(pushDirection * 2.5f, ForceMode.VelocityChange);
        }
        else
        {
            isRaning = false;
        }

        if (isRaning)
        {
            animator.SetBool("walk", _playerControllerScr.isTakeItem);
            animator.SetBool("run", !_playerControllerScr.isTakeItem && !_playerControllerScr.isPushingBox);
            animator.SetBool("idle", false);
            animator.SetBool("idle2", false);
            animator.SetBool("pushing", _playerControllerScr.isPushingBox);

        }
        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("idle", !_playerControllerScr.isTakeItem);
            animator.SetBool("idle2", _playerControllerScr.isTakeItem);
            animator.SetBool("pushing", false);

        }

        if (isRotating)
        {
            playerBodyTrans.localRotation = Quaternion.Lerp(playerBodyTrans.localRotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(playerBodyTrans.localRotation, targetRotation) < 1f)
            {
                isRotating = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            if (!_playerControllerScr.isTakeItem)
            {
                animator.SetTrigger("jump");
                isJumping = true;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
            
        }
    }

    private void playerMove(Vector3 PosDirection, float targetRot)
    {
        if (_playerControllerScr.isTakeItem)
        {
            transform.Translate(PosDirection * (moveSpeed - 3f) * Time.deltaTime);
        }
        else if (_playerControllerScr.isPushingBox)
        {
            transform.Translate(PosDirection * (moveSpeed - 4f) * Time.deltaTime);
        }
        else
        {
            transform.Translate(PosDirection * moveSpeed * Time.deltaTime);
        }
        targetRotation = Quaternion.Euler(0f, targetRot, 0f);
        isRotating = true;
        isRaning = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

    private float isCheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float distanceToGround = hit.distance;
            return distanceToGround;
        }
        else
        {
            return 0.0f;
        }
    }

    void keyPushPress()
    {
        _isPressW = Input.GetKey(KeyCode.W);
        _isPressA = Input.GetKey(KeyCode.A);
        _isPressS = Input.GetKey(KeyCode.S);
        _isPressD = Input.GetKey(KeyCode.D);
        _isPressQ = Input.GetKeyDown(KeyCode.Q);
    }
}
