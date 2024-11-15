using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatsSo playerSO;


    private Rigidbody _rb;
    private Animator _animator;
    private Transform _camera;
    private float _xMovement, _yMovement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _camera = Camera.main.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
        RotationHandler();

        var velocity = _rb.velocity;
        velocity.y = 0;
        if (velocity.magnitude > 0.01f) _animator.SetBool("IsRun", true);
        else _animator.SetBool("IsRun", false);
    }

    private void MovementHandler()
    {
        _xMovement = Input.GetAxis("Horizontal");
        _yMovement = Input.GetAxis("Vertical");

        Vector3 direction = _camera.forward * _yMovement + _camera.right * _xMovement;
        direction.Normalize();
        direction.y = 0;
        direction.y = _rb.velocity.y;

        direction *= playerSO.playerSpeed;
        _rb.velocity = direction;
    }

    private void RotationHandler()
    {
        Vector3 targetDir = _camera.forward * _yMovement + _camera.right * _xMovement;
        targetDir.Normalize();
        targetDir.y = 0;

        if(targetDir == Vector3.zero) targetDir = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDir);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, playerSO.playerRotationSpeed);
        transform.rotation = playerRotation;
    }
}
