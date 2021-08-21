using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : MonoBehaviour
{
    [SerializeField] private string _lable;
    //[SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _magnificationFactorCoin;
    [SerializeField] private float _magnificationFactorBlood;


    public float Price = 2;
    public string Lable => _lable;
    //public int Price => _price;
    public Sprite Icon => _icon;       

    public void Buy(Player player)
    {        
        Price = Price * 2;
        player.AddFactorMoney(_magnificationFactorCoin, _magnificationFactorBlood);
    }   
}
