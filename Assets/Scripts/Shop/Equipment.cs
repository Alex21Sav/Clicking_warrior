using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : MonoBehaviour
{
    [SerializeField] private string _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _magnificationFactorCoin;
    [SerializeField] private float _magnificationFactorBlood;

    private float _priceSave;

    public float Price = 2;
    public string Lable => _lable;
    public Sprite Icon => _icon;

    private void Awake()
    {
        _priceSave = Price;
    }
    private void Start()
    {
        Price = PlayerPrefs.GetFloat("Price");
    }
    public void Buy(Player player)
    {        
        Price = Price * 2;
        PlayerPrefs.SetFloat("Price", Price);
        player.AddFactorMoney(_magnificationFactorCoin, _magnificationFactorBlood);
    } 
    
    //public void ResetSaveEquipment()
    //{
    //    Price = _priceSave;
    //    PlayerPrefs.DeleteKey("Price");
    //}
}
