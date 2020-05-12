using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShittyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotSpeed = 100f;
    [SerializeField] private Rigidbody rb = default;
    [SerializeField] private Transform home = default;
    [SerializeField] private LayerMask whatIsGround = default;
    [SerializeField] private float jumpForce = 8f;
    private bool canJump = true;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Screen.SetResolution(1920, 1080, true);
    }

    private void Update()
    {
        Rotate();
        if (Input.GetKeyDown(KeyCode.Space)) 
            Jump();
    }
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 moveV = transform.forward * Input.GetAxis("Vertical");
        Vector3 moveH = transform.right * Input.GetAxis("Horizontal");

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
            rb.AddExplosionForce(jumpForce, transform.position, 1f, 5f, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == whatIsGround) { canJump = true; }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == whatIsGround) { canJump = false; }
    }

}
