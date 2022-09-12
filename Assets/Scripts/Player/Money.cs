using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Money : MonoBehaviour
{
    public static int PlayerMoney { get; private set; } = 100;


    public static event UnityAction<int> MoneyChanged;
    public static void AddMoney(int plusSum)
    {
        if (plusSum > 0)
        {
            PlayerMoney += plusSum;
            MoneyChanged?.Invoke(PlayerMoney);
        }    
    }

    public static void SpendMoney(int minusSum)
    {
        if (PlayerMoney > 0)
        {
            PlayerMoney -= minusSum;
            MoneyChanged?.Invoke(PlayerMoney);
        }
    }
    
}
