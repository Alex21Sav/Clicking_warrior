using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Crow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _targetLostPosition;
    private Tweener _tween;
    private void Start()
    {
        _tween = transform.DOMove(_target.position, 2).SetAutoKill(false);
        _targetLostPosition = _target.position;
    }
    private void Update()
    {
        if (_targetLostPosition != _target.position)
        {
            _tween.ChangeEndValue(_target.position, true).Restart();
            _targetLostPosition = _target.position;

        }
    }
}
