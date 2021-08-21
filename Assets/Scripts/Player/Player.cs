using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource _coinSound; 

    private float _magnificationFactorMoney = 1;
    private float _magnificationFactorBlood = 1;
    public float Money { get; private set; }
    public float Blood { get; private set; }

    public event UnityAction<float> MoneyChanget;
    public event UnityAction<float> BloodChanget;
    public void AddReward(float money)
    {
        _coinSound.pitch = Random.Range(0.9f, 1.1f);
        _coinSound.Play();
        Money += money *_magnificationFactorMoney;
        MoneyChanget?.Invoke(Money);
    }
    public void AddReward(float money, float blood)
    {
        Money += money * _magnificationFactorMoney;
        Blood += blood * _magnificationFactorBlood;
        MoneyChanget?.Invoke(Money);
        BloodChanget?.Invoke(Blood);
    }
    public void AddFactorMoney(float factorMoney, float factorBlood)
    {
        _magnificationFactorMoney = _magnificationFactorMoney + factorMoney;
        _magnificationFactorBlood = _magnificationFactorBlood + factorBlood;
        
    }

    //public void AddFactorBlood(float factor)
    //{
    //    _magnificationFactorBlood = _magnificationFactorBlood + factor;
    //}
    public void BuyEquipment(Equipment equipment)
    {
        Money -= equipment.Price;
        MoneyChanget?.Invoke(Money);        
        Debug.Log($"Совершили покупку");
    }
}
