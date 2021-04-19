using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public GameController gc;

    private int money;

    public int ChangingMoney(int moneyAmount)
    {
        money += moneyAmount;
        return money;
    }
}
