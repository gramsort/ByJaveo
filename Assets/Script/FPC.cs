using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPC : MonoBehaviour
{
    private Rigidbody rb;

    public Camera playerCamera;
    public float mouseSensitivity = 3f;
    public float maxLookAngle = 90f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public float moveSpeed = 10f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch = pitch - Input.GetAxis("Mouse Y") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        transform.localEulerAngles = new Vector3(0, yaw, 0);
        playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        targetVelocity = transform.TransformDirection(targetVelocity) * moveSpeed;

        Vector3 velocityChange = targetVelocity - rb.velocity;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
