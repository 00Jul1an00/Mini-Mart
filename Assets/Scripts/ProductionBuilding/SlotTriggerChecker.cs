using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SlotTriggerChecker : MonoBehaviour
{
    [SerializeField] protected float _delay;

    public event Action PlayerEnteredInTrigger;

    private Coroutine _delayRoutine;
    private bool _isNotYetCalled = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player) && _isNotYetCalled)
            _delayRoutine = StartCoroutine(WaitingDelay(_delay));
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
        {
            StopCoroutine(_delayRoutine);
            _isNotYetCalled = true;
        }
    }

    private IEnumerator WaitingDelay(float delay)
    {
        _isNotYetCalled = false;
        yield return new WaitForSeconds(delay);
        
        PlayerEnteredInTrigger?.Invoke();
    }
}
