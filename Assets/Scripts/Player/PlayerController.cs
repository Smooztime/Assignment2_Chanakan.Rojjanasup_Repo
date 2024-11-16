using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerDied
{
    [SerializeField] private PlayerStatsSo playerSO;

    public PlayerStatsSo PlayerStatsSo => playerSO;


    private Rigidbody _rb;
    private Animator _animator;
    private Transform _camera;
    private float _xMovement, _yMovement;
    private Vector3 _startPos;
    private bool _controllerActive = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _camera = Camera.main.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = _rb.velocity;
        velocity.y = 0;
        if (velocity.magnitude > 0.01f) _animator.SetBool("IsRun", true);
        else _animator.SetBool("IsRun", false);

        if (!_controllerActive) return;
        MovementHandler();
        RotationHandler();
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

    private IEnumerator DisableControl()
    {
        _rb.velocity = Vector3.zero;
        _controllerActive = false;
        yield return new WaitForSeconds(3);
        transform.position = _startPos;
        _controllerActive = true;
    }

    public void OnPlayerDied()
    {
        StartCoroutine(DisableControl());
    }
}
