using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _shop;

    public void Open()
    {
        _shop.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close()
    {
        _shop.SetActive(false);
        Time.timeScale = 1;
    }

    public void ToggleOpen()
    {
        if (_shop.activeSelf)
            Close();
        else
            Open();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
