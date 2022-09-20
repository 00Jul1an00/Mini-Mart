using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductInteraction : MonoBehaviour 
{
    private static float _duration = 3f;
    private static float _elapsedTime;
    public static void TakeProduct(Product product, GameObject holdZone)
    {
        product.transform.position = Vector3.Lerp(product.transform.position, holdZone.transform.position, _duration);
    }

    private static void PutProduct()
    {

    }

    
}
