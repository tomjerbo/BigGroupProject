using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Toolkit;

public class ShittyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotSpeed = 100f;
    [SerializeField] public Rigidbody rb = default;
    [SerializeField] private Transform home = default;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private LayerMask jumpableLayers = default;
    private float jumpCD = 0.2f;
    private float jumpTimer = 0f;
    private bool canJump = true;
    public bool onLadder = false;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Start()
    {
        GameEvent.instance.OnPlayerDeath += Respawn;
    }

    private void Respawn(Transform location)
    {
        transform.position = location.position;
    }

    private void Update()
    {
        Rotate();
        if (Input.GetKeyDown(KeyCode.Space)) 
            Jump();

        if (jumpTimer <= 0)
        {
            CheckForGround();
        }
        else
        {
            jumpTimer -= Time.deltaTime;
        }
        print("Can jump = " + canJump);
    }
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 moveV = transform.forward * Input.GetAxis("Vertical");
        Vector3 moveH = transform.right * Input.GetAxis("Horizontal");

        if (onLadder)
        {
            moveV = home.forward * Input.GetAxis("Vertical");
        }

        if (!canJump)
        {
            if (moveH != Vector3.zero)
                moveH = moveH * 0.35f;

        }

        rb.MovePosition(transform.position + ((moveV + moveH) * moveSpeed * Time.deltaTime)); 

    }

    private void Rotate()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotX);

        float rotY = -Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        home.Rotate(Vector3.right, rotY);
    }

    private void Jump()
    {
        if (canJump)
        {
            if (onLadder) rb.AddForce(home.forward * jumpForce, ForceMode.Impulse);
            else rb.AddExplosionForce(jumpForce, transform.position, 1f, 5f, ForceMode.Impulse);
            canJump = false;
            jumpTimer = jumpCD;
            if (onLadder) jumpTimer += jumpCD;
        }
    }

    private void CheckForGround()
    {
        canJump = false;
        RaycastHit[] hits = Physics.BoxCastAll(transform.position + Vector3.down, Vector3.one * 0.35f, transform.up, Quaternion.identity);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.layer.Contains(jumpableLayers))
            {
                canJump = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ladder"))
        {
            onLadder = true;
            rb.velocity = rb.velocity * 0.9f;
            rb.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ladder"))
        {
            onLadder = false;
            rb.useGravity = true;
        }
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up, Vector3.one * 0.35f);
    }
}
