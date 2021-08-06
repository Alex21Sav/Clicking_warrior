using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int Money { get; private set; }
    public int Blood { get; private set; }


    public event UnityAction<int> MoneyChanget;
    public event UnityAction<int> BloodChanget;

    public void AddReward(int money)
    {
        Money += money;
        Debug.Log($"{Money}");
        MoneyChanget?.Invoke(Money);
    }

    public void AddReward(int money, int blood)
    {
        Money += money;
        Blood += blood;
        Debug.Log($"{Money} , {Blood}");
        MoneyChanget?.Invoke(Money);
        BloodChanget?.Invoke(Blood);
    }
}
