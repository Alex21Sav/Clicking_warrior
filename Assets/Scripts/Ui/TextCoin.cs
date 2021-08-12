using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCoin : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _coin;

    private void OnEnable()
    {
        _player.MoneyChanget += OnMoneyChanget;
    }
    private void OnDisable()
    {
        _player.MoneyChanget -= OnMoneyChanget;
    }
    private void OnMoneyChanget(int blood)
    {
        _coin.text = blood.ToString();
    }
}
