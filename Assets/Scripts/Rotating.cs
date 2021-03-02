using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotating : MonoBehaviour
{
    [SerializeField] private float _startDelay = 0;
    [SerializeField] private float _speed = 1;

    private bool _isRotate = true;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        StartCoroutine(Rotate());
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isRotate = false;
        _rigidbody.useGravity = true;
    }

    private IEnumerator Rotate()
    {
        yield return new WaitForSeconds(_startDelay);

        while(_isRotate)
        {
            transform.Rotate(new Vector3(0, _speed, 0));
            yield return null;
        }
    }
}
