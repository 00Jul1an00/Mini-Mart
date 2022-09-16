using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITakable : MonoBehaviour
{
    private bool _isHold = false;
    private float _distance = 1f;
    private RaycastHit2D _hit;
    private void TakeProduct()
    {
        if (!_isHold)
        {
            Physics2D.queriesStartInColliders = false;
            _hit = Physics2D.Raycast(transform.position, transform.forward, _distance);
        }
    }

    private void PutProduct()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward * _distance);
    }
}
