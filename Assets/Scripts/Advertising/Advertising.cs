using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Advertising : MonoBehaviour
{
    [SerializeField] private Image _timerBar;
    [SerializeField] private float _maTime = 20f;
    [SerializeField] private float _bonusX = 2;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _timer;

    private bool _isButton = false;
    private float _timeLeft;    

    public event UnityAction<float> BonusActivation;

    private void Start()
    {        
        _timeLeft = _maTime;        
    }
    private void Update()
    {
        if (_timeLeft > 0 && _isButton)
        {
            _timeLeft -= Time.deltaTime;
            _timerBar.fillAmount = _timeLeft / _maTime;            

            BonusActivation?.Invoke(_bonusX);

            if (_timeLeft <= 0)
            {
                _isButton = false;
                _timer.SetActive(false);
                _timerBar.fillAmount = _maTime;
                _timeLeft = _maTime;
                BonusActivation?.Invoke(1f);
            }           
        }        
    }
    public void OnButtonClick()
    {
        _isButton = true;
        _timer.SetActive(true);
    }
}
