using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductInteraction : MonoBehaviour
{
    private bool _isHold = false;
    private float _distance = 1f;
    private RaycastHit2D _hit;
    private void TakeProduct(Collider col)
    {
        if (!_isHold)
        {
            Physics2D.queriesStartInColliders = false;
            _hit = Physics2D.Raycast(transform.position, transform.forward, _distance);

            if(_hit.collider == col)
            {

            }
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
