using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductInteraction : MonoBehaviour 
{
    private static float _duration = 1f;
    private static float _elapsedTime;
    private static bool _isHold;
    private static Vector3 _currentProductPosition;
    private static Vector3 _currentHoldZonePosition;

    private void Update()
    {
        if (_isHold)
            _currentProductPosition = _currentHoldZonePosition;
    }
    public static void TakeProduct(Product product, GameObject holdZone)
    {
        product.transform.position = Vector3.Lerp(product.transform.position, holdZone.transform.position, _duration);
        _currentProductPosition = product.transform.position;
        _currentHoldZonePosition = holdZone.transform.position;
        _isHold = true;
        

    }

    private static void PutProduct()
    {

    }

    
}
