using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //This script used Single Responsibility about Player Controller Only
    [SerializeField] private PlayerStatsSo playerSO;

    public PlayerStatsSo PlayerStatsSo => playerSO;


    private Rigidbody _rb;
    private Animator _animator;
    private Transform _camera;
    private float _xMovement, _yMovement;
    private Vector3 _startPos;
    private bool _controllerActive = true;

    public Rigidbody RB=> _rb;
    public Vector3 StartPos => _startPos;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        _startPos = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var velocity = _rb.velocity;
        velocity.y = 0;
        if (velocity.magnitude > 0.01f) _animator.SetBool("IsRun", true);
        else _animator.SetBool("IsRun", false);

        if (!_controllerActive) return;
        MovementHandler();
    }

    private void MovementHandler()
    {
        _xMovement = Input.GetAxis("Horizontal");
        _yMovement = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(_xMovement, 0f, _yMovement);
        direction.y = 0f;
        direction.Normalize();

        
        _rb.velocity = direction;
        _rb.velocity *= playerSO.playerSpeed;

        if(direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, playerSO.playerRotationSpeed);
        }
    }

    //Create a method that other script can used this with closed to fix when need to deactivate controller
    public void ControllerActive(bool value)
    {
    _controllerActive = value;
    }
}
