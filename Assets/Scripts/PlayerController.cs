﻿using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 5.0f;
    float bonusSpeed;
    float bonusSpeedTimer;
    public float rotationSpeed = 5.0f;
    public float jumpForce = 50.0f;
    public float impulseForce = 5.0f;
    public float impulseFreezeTime = 3.0f;

    [Header("Camera")]
    public Transform cameraPivot = null;
    public float cameraSpeedInXRotation = 50.0f;

    private Rigidbody _rigidbody = null;
    private InputManager _input = null;

    [Header("Skills")]
    private int _currentAmmo = 20;
    public int currentAmmo { get => _currentAmmo; set { _currentAmmo = Mathf.Clamp(value, 0, 99); } }
    public Transform shootPosition = null;

    public AbstractSkill skillAssociated = null;

    [Header("Jump")]
    public LayerMask floorLayer;
    public float distanceToGroundForJump = 0.3f;

    [Header("SFX")]
    public AudioSource maskThrowSFX = null;

    private bool impulsed = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = GetComponent<InputManager>();

        if (skillAssociated)
        {
            skillAssociated.Init();
        }
    }

    private void Update()
    {
        Rotation();
        Movement();
        Jump();
        ActivateSkill();

        if(bonusSpeed!=0)
        {
            bonusSpeedTimer -= Time.deltaTime;
            if(bonusSpeedTimer < 0)
            {
                bonusSpeed = 0;
            }
        }

    }

    private void Movement()
    {
        if (impulsed) return;
        // Reset forces to not accumulate acceleration. In Y axis not applies due gravity reasons
        _rigidbody.velocity = new Vector3(0.0f, _rigidbody.velocity.y, 0.0f);

        // Forces to add in local coordinates
        Vector3 forcesToAdd = (transform.forward * _input.MovementInput.y) + (transform.right * _input.MovementInput.x);
        //_rigidbody.AddForce(forcesToAdd.normalized*speed, ForceMode.Force);
        float totalSpeed = speed + bonusSpeed;
        _rigidbody.MovePosition(transform.position + (forcesToAdd.normalized * totalSpeed));
    }

    private void Rotation()
    {
        // Rotate the whole player
        transform.Rotate(new Vector3(0.0f, _input.CameraInput.x, 0.0f) * rotationSpeed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        if (_input.JumpInput && IsGrounded())
        {
            _rigidbody.AddForce(transform.up*jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        if(Physics.Raycast(transform.position, -Vector3.up, distanceToGroundForJump, floorLayer))
        {
            return true;
        }

        return false;
    }

    private void ActivateSkill()
    {
        if (_input.FireInput)
        {
            if (skillAssociated)
            {
                if(_currentAmmo>0 && !skillAssociated.Activated)
                {
                    skillAssociated.Activate(this);
                    _currentAmmo--;
                    maskThrowSFX.Play();
                }
            }
            else
            {
                Debug.LogWarning("Skill not set");
            }
        }
    }

    public void AddImpulse(Vector3 attackerForward)
    {
        _rigidbody.AddForce(attackerForward * impulseForce, ForceMode.Impulse);
        impulsed = true;
        DOVirtual.DelayedCall(impulseFreezeTime, () => impulsed = false);
    }

    internal void IncreaseSpeed(float bonusSpeed, float duration)
    {
        this.bonusSpeed = bonusSpeed;
        bonusSpeedTimer = duration;
    }


    internal void AddAmmo(int ammo, AbstractSkill newSkill)
    {
        if(skillAssociated == newSkill)
        {
            currentAmmo += 10;
        }
        else
        {
            skillAssociated = newSkill;
            currentAmmo = 10;
        }
    }

}
