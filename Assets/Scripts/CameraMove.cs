using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    public static CameraMove Instance;

    private Rigidbody _rigidbody;
    private bool _moving = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        GameplayController.Instance.OnStarted += StartMovement;
    }

    public void StartMovement()
    {
        _moving = true;
    }

    public void StopMovement()
    {
        _moving = false;
    }

    private void FixedUpdate()
    {
        if (_moving) _rigidbody.MovePosition(_rigidbody.position + Vector3.forward * _speed);
    }
}
