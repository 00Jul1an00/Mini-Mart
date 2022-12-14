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
    public static Transform PlayerTransform;
    
    

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _chController = GetComponent<CharacterController>(); 
        PlayerTransform = GetComponent<Transform>(); 
       
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
        //_rigidBody.AddForce(transform.up * -1);


        if (Vector3.Angle(Vector3.forward, _directionVector) > 1 || Vector3.Angle(Vector3.forward, _directionVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _directionVector, _playerSpeed, 0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
    }
}
