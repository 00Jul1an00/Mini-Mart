using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPutProductTrigger : PlayerInteracter
{
    protected override Tuple<Action, Action<Product>> SetActionsBehaivor()
    {
        Action buildingAction = _building.AddProduct;
        Action<Product> playerAction = _player.PutProduct;

        return Tuple.Create(buildingAction, playerAction) ;
    }

    protected override bool SetConditions()
    {
        return _player.CanPutProduct && _building.CanAddProduct;
    }
}
