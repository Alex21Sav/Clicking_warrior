using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBlood : MonoBehaviour
{
    [SerializeField] private List<Equipment> _equipments;
    [SerializeField] private Player _player;
    [SerializeField] private EquipmentView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _equipments.Count; i++)
        {
            AddItem(_equipments[i]);
        }
    }
    private void AddItem(Equipment equipment)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellBloodButtonClick;
        view.Render(equipment);
    }
    public void OnSellBloodButtonClick(Equipment equipment, EquipmentView view)
    {
        if (equipment.Price <= _player.Blood)
        {
            _player.BuyEquipmentBlood(equipment);
            equipment.Buy(_player);
            view.Render(equipment);
        }
    }
}
