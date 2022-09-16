using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabProductTrigger : PlayerInteracter
{
    protected override Tuple<Action, Action<Product>> SetActionsBehaivor()
    {
        Action buildingAction = _building.RemoveProduct;
        Action<Product> playerAction = _player.TakeProduct;

        return Tuple.Create(buildingAction, playerAction);
    }

    protected override bool SetConditions()
    {
        return _building.CanRemoveProduct && _player.CanTakeProduct;
    }
}
