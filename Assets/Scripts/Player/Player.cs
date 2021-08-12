using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _magnificationFactorMoney = 1;
    //private int _magnificationFactorBlood = 0;
    public int Money { get; private set; }
    public int Blood { get; private set; }

    public event UnityAction<int> MoneyChanget;
    public event UnityAction<int> BloodChanget;
    public void AddReward(int money)
    {
        Money += money *_magnificationFactorMoney;
        Debug.Log($"{Money}");
        MoneyChanget?.Invoke(Money);
    }
    public void AddReward(int money, int blood)
    {
        Money += money * _magnificationFactorMoney;
        Blood += blood;
        Debug.Log($"{Money} , {Blood}");
        MoneyChanget?.Invoke(Money);
        BloodChanget?.Invoke(Blood);
    }
    public void AddFactorMoney(int factor)
    {
        _magnificationFactorMoney = _magnificationFactorMoney + factor;
    }
    public void BuyEquipment(Equipment equipment)
    {
        Money -= equipment.Price;
        MoneyChanget?.Invoke(Money);        
        Debug.Log($"Совершили покупку");
    }
}
