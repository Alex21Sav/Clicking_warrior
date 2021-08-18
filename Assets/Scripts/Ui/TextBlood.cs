using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBlood : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _blood;

    private void OnEnable()
    {
        _player.BloodChanget += OnBloodChanget;
    }
    private void OnDisable()
    {
        _player.BloodChanget -= OnBloodChanget;
    }
    private void OnBloodChanget(float blood)
    {
        _blood.text = ControllingNumberFormat.NumberFormat(blood);
    }
}
