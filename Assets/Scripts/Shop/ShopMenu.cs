using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _shopBlood;
    [SerializeField] private GameObject _mainMenu;


    public void Shop()
    {
        _shop.SetActive(true);
        _shopBlood.SetActive(false);
        _mainMenu.SetActive(false);
        Time.timeScale = 0;
    }

    public void ShopBlood()
    {
        _shop.SetActive(false);
        _shopBlood.SetActive(true);
        _mainMenu.SetActive(false);
        Time.timeScale = 0;
    }
    public void MainMenu()
    {
        _shop.SetActive(false);
        _shopBlood.SetActive(false);
        _mainMenu.SetActive(true);
        Time.timeScale = 0;
    }


    //public void Open()
    //{
    //    _shop.SetActive(true);
    //    Time.timeScale = 0;
    //}

    //public void Close()
    //{
    //    _shop.SetActive(false);
    //    Time.timeScale = 1;
    //}

    //public void ToggleOpen()
    //{
    //    if (_shop.activeSelf)
    //        Close();
    //    else
    //        Open();
    //}

    //public void Exit()
    //{
    //    Application.Quit();
    //}
}
