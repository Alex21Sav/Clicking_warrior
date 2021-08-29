using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Advertising : MonoBehaviour
{
    [SerializeField] private Image _timerBar;
    [SerializeField] private float _maTime = 20f;
    [SerializeField] private float _bonusX = 2;
    [SerializeField] private Player _player;    

    private bool _isButton = false;
    private float _timeLeft;
    void Start()
    {        
        _timeLeft = _maTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeLeft > 0 && _isButton)
        {
            _timeLeft -= Time.deltaTime;
            _timerBar.fillAmount = _timeLeft / _maTime;
            Bonus(_player);

            if(_timeLeft == 0)
            {
                _isButton = false;
            }           
        }        
    }   

    private void Bonus(Player player)
    {
        player.BonusActivation(_bonusX);
    }

    public void OnButtonClick()
    {
        _isButton = true;
    }
}
