using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSliding : MonoBehaviour
{
    [SerializeField] private float _sensetivity;
    [SerializeField] private float _clampX;
    [SerializeField] private float _clampZ;


    private Vector3 _start;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) _start = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            float x = Mathf.Clamp(Input.GetAxis("Mouse X"),-1,1);
            float z = Mathf.Clamp(Input.GetAxis("Mouse Y"),-1,1);

            Vector3 input = new Vector3(x, 0, z) * _sensetivity * Time.deltaTime;

            transform.position += input;

            Vector3 position = transform.position;
            position.x = Mathf.Clamp(position.x, -_clampX, _clampX);
            position.z = Mathf.Clamp(position.z, transform.parent.position.z + transform.localScale.z, transform.parent.position.z + _clampZ);
            transform.position = position;
        }
    }
}
