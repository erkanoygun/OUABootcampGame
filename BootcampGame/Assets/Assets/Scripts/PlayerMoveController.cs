using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Animator animator;

    bool isRaning;
    public float moveSpeed = 5f;
    public float rotationSpeed = 7f;

    private Quaternion targetRotation;
    private bool isRotating = false;

    public float jumpForce = 5f;
    private bool isJumping = false;
    private Rigidbody rb;

    private PlayerController _playerControllerScr;

    Transform playerBodyTrans;

    bool _isPressW = false;
    bool _isPressA = false;
    bool _isPressS = false;
    bool _isPressD = false;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerBodyTrans = transform.GetChild(0);
        targetRotation = playerBodyTrans.localRotation;
        rb = GetComponent<Rigidbody>();

        _playerControllerScr = GetComponent<PlayerController>();
    }

    void Update()
    {
        isRaning = false;

        _isPressW = Input.GetKey(KeyCode.W);
        _isPressA = Input.GetKey(KeyCode.A);
        _isPressS = Input.GetKey(KeyCode.S);
        _isPressD = Input.GetKey(KeyCode.D);

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

        if (isRaning)
        {
            if (_playerControllerScr.isTakeBox)
            {
                animator.SetBool("walk", true);
                animator.SetBool("run", false);
                animator.SetBool("idle", false);
                animator.SetBool("idle2", false);
            }
            else
            {
                animator.SetBool("run", true);
                animator.SetBool("walk", false);
                animator.SetBool("idle", false);
                animator.SetBool("idle2", false);
            }

        }
        else
        {
            if (_playerControllerScr.isTakeBox)
            {
                animator.SetBool("run", false);
                animator.SetBool("walk", false);
                animator.SetBool("idle", false);
                animator.SetBool("pushing_idle", false);
                animator.SetBool("idle2", true);
            }
            else if (_playerControllerScr.isPushingBox)
            {
                animator.SetBool("run", false);
                animator.SetBool("walk", false);
                animator.SetBool("idle", false);
                animator.SetBool("idle2", false);
                animator.SetBool("pushing_idle", true);
            }
            else
            {
                animator.SetBool("run", false);
                animator.SetBool("walk", false);
                animator.SetBool("idle2", false);
                animator.SetBool("pushing_idle", false);
                animator.SetBool("idle", true);
            }
            
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
            if (!_playerControllerScr.isTakeBox)
            {
                animator.SetTrigger("jump");
                isJumping = true;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
            
        }
    }

    private void playerMove(Vector3 PosDirection, float targetRot)
    {
        if (_playerControllerScr.isTakeBox)
        {
            transform.Translate(PosDirection * (moveSpeed - 3f) * Time.deltaTime);
            isRaning = true;
        }
        else
        {
            transform.Translate(PosDirection * moveSpeed * Time.deltaTime);
            isRaning = true;
        }

        targetRotation = Quaternion.Euler(0f, targetRot, 0f);
        isRotating = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
