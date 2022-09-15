using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _cameraSpeed;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var nextPosition = Vector3.Lerp(transform.position, _targetTransform.position + _offset, Time.deltaTime * _cameraSpeed);
        transform.position = nextPosition;
    }
}
