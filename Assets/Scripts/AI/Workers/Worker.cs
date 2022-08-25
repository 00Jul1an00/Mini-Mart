using UnityEngine;

public abstract class Worker : MonoBehaviour
{
    [SerializeField] protected float _speed;

    public float Speed => _speed;
}
