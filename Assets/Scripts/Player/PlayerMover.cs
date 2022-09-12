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


        if (Vector3.Angle(Vector3.forward, _directionVector) > 1 || Vector3.Angle(Vector3.forward, _directionVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _directionVector, _playerSpeed, 0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
    }

    //Move to another script
    private Stack<Product> _inventory = new();
    private int _capacity = 2;
    
    public bool CanTakeProduct { get { return _inventory.Count < _capacity; } }

    public void TakeProduct(Product product)
    {
        if (CanTakeProduct)
            _inventory.Push(product);

        print(_inventory.Count);
    }

    public bool TryPutProduct(Product product)
    {
        if (_inventory.Count > 0 && _inventory.Peek() == product)
        {
            _inventory.Pop();
            print(_inventory.Count);
            return true;
        }
        else
            return false;
    }


}
