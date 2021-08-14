using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _magnificationFactorMoney = 1;
    //private int _magnificationFactorBlood = 0;
    public float Money { get; private set; }
    public float Blood { get; private set; }

    public event UnityAction<float> MoneyChanget;
    public event UnityAction<float> BloodChanget;
    public void AddReward(float money)
    {
        Money += money *_magnificationFactorMoney;
        Debug.Log($"{Money}");
        MoneyChanget?.Invoke(Money);
    }
    public void AddReward(float money, float blood)
    {
        Money += money * _magnificationFactorMoney;
        Blood += blood;
        Debug.Log($"{Money} , {Blood}");
        MoneyChanget?.Invoke(Money);
        BloodChanget?.Invoke(Blood);
    }
    public void AddFactorMoney(float factor)
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
