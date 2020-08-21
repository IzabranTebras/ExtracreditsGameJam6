﻿using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f;
    public float jumpForce = 50.0f;

    [Header("Camera")]
    public Transform cameraPivot = null;
    public float cameraSpeedInXRotation = 50.0f;

    private Rigidbody _rigidbody = null;
    private InputManager _input = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = GetComponent<InputManager>();
    }

    private void Update()
    {
        Rotation();
        CameraRotation();
        Movement();
        Jump();
    }

    private void Movement()
    {
        // Reset forces to not accumulate acceleration. In Y axis not applies due gravity reasons
        _rigidbody.velocity = new Vector3(0.0f, _rigidbody.velocity.y, 0.0f);

        // Forces to add in local coordinates
        Vector3 forcesToAdd = (transform.forward * _input.MovementInput.y) + (transform.right * _input.MovementInput.x);
        _rigidbody.AddForce(forcesToAdd.normalized*speed, ForceMode.Impulse);
    }

    private void Rotation()
    {
        // Rotate the whole player
        transform.Rotate(new Vector3(0.0f, _input.CameraInput.x, 0.0f) * rotationSpeed * Time.fixedDeltaTime);
    }

    //@TODO: Decidir si poner movimiento en camara o solo rotación de personaje como hay ahora
    private void CameraRotation()
    {
        //cameraPivot.Rotate(new Vector3(_input.CameraInput.y, 0.0f, 0.0f) * cameraSpeedInXRotation * Time.deltaTime);
    }

    private void Jump()
    {
        if (_input.JumpInput)
        {
            _rigidbody.AddForce(transform.up*jumpForce, ForceMode.Impulse);
        }
    }
}