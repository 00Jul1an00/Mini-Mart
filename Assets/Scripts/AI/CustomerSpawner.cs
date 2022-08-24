using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Customer _customerPrefab;
    [SerializeField] private int _maxSpawnCount;
    [SerializeField] private float _timeBetweenSpawn;

    private float _currentTime;
    private int _currentQuantityOfSpawnedCustomers;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= _timeBetweenSpawn && _currentQuantityOfSpawnedCustomers < _maxSpawnCount)
        {
            Customer customer = Instantiate(_customerPrefab, _spawnPoint.position, Quaternion.identity, transform);
            customer.Init(this);
            _currentQuantityOfSpawnedCustomers++;
            _currentTime = 0;
        }
    }

    private void OnEnable()
    {
        MoveToExitState.IsDestroy += OnDestroyCustomer;
    }

    private void OnDisable()
    {
        MoveToExitState.IsDestroy -= OnDestroyCustomer;
    }

    private void OnDestroyCustomer()
    {
        _currentQuantityOfSpawnedCustomers--;
    }
}
