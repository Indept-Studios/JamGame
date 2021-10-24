using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public GameController gameController;

   [field: SerializeField]
    public int Money { get;  set; }

    public int ChangingMoney(int moneyAmount)
    {
        Money += moneyAmount;
        return Money;
    }
}
