using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SlotTriggerChecker : MonoBehaviour
{
    public event Action PlayerEnteredInTrigger;

    private bool _isNoAnyInput;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
        {
            _isNoAnyInput = player.IsNoAnyInput;
                StartCoroutine(WaitingDelay(2));
        }
        else
        {
            _isNoAnyInput = false;
            StopCoroutine(WaitingDelay(2));
        }
    }

    private IEnumerator WaitingDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if(_isNoAnyInput)
            PlayerEnteredInTrigger?.Invoke();
    }
}
