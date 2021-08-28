using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource _coinSound;

    private float _magnificationFactorMoney;
    private float _magnificationFactorBlood;
    public float Money { get; private set; }
    public float Blood { get; private set; }

    public event UnityAction<float> MoneyChanget;
    public event UnityAction<float> BloodChanget;

    private void Start()
    {        
        Money = PlayerPrefs.GetFloat("MoneySave");
        Blood = PlayerPrefs.GetFloat("BloodSave");

        MoneyChanget?.Invoke(Money);
        BloodChanget?.Invoke(Blood);

        _magnificationFactorMoney = PlayerPrefs.GetFloat("FactorMoneySave");
        _magnificationFactorBlood = PlayerPrefs.GetFloat("FactorBloodSave");
    }
    public void AddReward(float money)
    {
        _coinSound.pitch = Random.Range(0.9f, 1.1f);
        _coinSound.Play();
        Money += money * _magnificationFactorMoney;
        MoneyChanget?.Invoke(Money);
    }
    public void AddReward(float money, float blood)
    {
        Money += money + money * _magnificationFactorMoney;
        Blood += blood + blood * _magnificationFactorBlood;
        MoneyChanget?.Invoke(Money);
        BloodChanget?.Invoke(Blood);
        PlayerPrefs.SetFloat("MoneySave", Money);
        PlayerPrefs.SetFloat("BloodSave", Blood);
    }
    public void AddFactorMoney(float factorMoney, float factorBlood)
    {
        _magnificationFactorMoney += factorMoney;
        _magnificationFactorBlood += factorBlood;

        PlayerPrefs.SetFloat("FactorMoneySave", _magnificationFactorMoney);
        PlayerPrefs.SetFloat("FactorBloodSave", _magnificationFactorBlood);
    }
    public void BuyEquipment(Equipment equipment)
    {
        Money -= equipment.Price;
        PlayerPrefs.SetFloat("MoneySave", Money);
        MoneyChanget?.Invoke(Money);        
        Debug.Log($"Совершили покупку");
    }
    public void BuyEquipmentBlood(Equipment equipment)
    {
        Blood -= equipment.Price;
        PlayerPrefs.SetFloat("BloodSave", Blood);
        BloodChanget?.Invoke(Blood);
        Debug.Log($"Совершили покупку");
    }
}
