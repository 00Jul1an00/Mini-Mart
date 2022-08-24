using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int PlayerMoney { get; private set; } = 100;
    
    public void AddMoney()
    {

    }

    public static void SpendMoney(int minusSum)
    {
        if (PlayerMoney > 0)
        {
            PlayerMoney -= minusSum;
        }
    }
    
}
