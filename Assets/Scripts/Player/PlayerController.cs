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
    }
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
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
    }

    private void MovementHandler()
    {
        _xMovement = Input.GetAxis("Horizontal");
        _yMovement = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(_xMovement, 0f, _yMovement);
        direction.Normalize();

        transform.Translate(direction * playerSO.playerSpeed * Time.deltaTime, Space.World);
        _rb.velocity = direction;

        if(direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, playerSO.playerRotationSpeed);
        }
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
