using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SlotTriggerChecker : MonoBehaviour
{
    [SerializeField] private float _delay;

    public event Action PlayerEnteredInTrigger;

    private Coroutine _delayRoutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
            _delayRoutine = StartCoroutine(WaitingDelay(_delay));
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
            StopCoroutine(_delayRoutine);
    }

    private IEnumerator WaitingDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
       
        PlayerEnteredInTrigger?.Invoke();
        Destroy(this);
    }
}
