using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private float _timeAnimationDeath = 0;

    private void Start()
    {        
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.TryGetComponent(out Destroye destroye))
        {
            Die();
        }
        else if(collision.TryGetComponent(out Player player))
        {
            _timeAnimationDeath += Time.deltaTime;
            _animator.Play("death");

            if (_timeAnimationDeath > 2)
            {
                Die();
            }

        }            
    }
    private void Die()
    {
        Destroy(gameObject);        
    }
}
