using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipmentView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Equipment _equipment;

    public event UnityAction<Equipment, EquipmentView> SellButtonClick;
    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);        
    }   
    public void Render(Equipment equipment)
    {
        _equipment = equipment;
        _lable.text = equipment.Lable;
        _price.text = equipment.Price.ToString();
        _icon.sprite = equipment.Icon;
    }
    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_equipment, this);
    }
}
