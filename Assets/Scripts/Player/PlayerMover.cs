using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private Rigidbody _rigidBody;
    private CharacterController _chController;
    private Vector3 _directionVector;
    private float _playerSpeed = 5f;
    private Transform _playerTransform;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _chController = GetComponent<CharacterController>(); 
        _playerTransform = GetComponent<Transform>(); 
        
    }
    
    void Update()
    {
        Movement();
    }

    private void Movement()
    {      
        _directionVector.x = Input.GetAxis("Horizontal") * _playerSpeed;
        _directionVector.z = Input.GetAxis("Vertical") * _playerSpeed;
        _chController.Move(_directionVector * Time.deltaTime);
        if (_playerTransform.transform.hasChanged == true)
            _particleSystem.Play();
            

            

        if (Vector3.Angle(Vector3.forward, _directionVector) >1 || Vector3.Angle(Vector3.forward, _directionVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _directionVector, _playerSpeed, 0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
    }
}
