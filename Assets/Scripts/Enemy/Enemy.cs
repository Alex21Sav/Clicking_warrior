using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _money;
    [SerializeField] private float _blood;
    [Header("Effect")]
    [SerializeField] private GameObject _effectDie;
    [SerializeField] private AudioSource _dieSound;

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

            player.AddReward(_money, _blood);

            _dieSound.pitch = Random.Range(0.9f, 1.1f);
            _dieSound.Play();

            _animator.Play("death");

            Instantiate(_effectDie, transform.position, Quaternion.identity);

            var ColliderEnemy = gameObject.GetComponent<Collider2D>();
            Destroy(ColliderEnemy);

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
