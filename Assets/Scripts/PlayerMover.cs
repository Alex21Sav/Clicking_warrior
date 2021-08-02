using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse = 10;

    private bool _isGraunded;
    private Rigidbody2D _rigidbody;
    private Animator _animator;



    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
        CheckGraunded();

        if (_isGraunded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        CheckGraunded();
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForse, ForceMode2D.Impulse);
    }

    private void Run()
    {
        transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
    }

    private void CheckGraunded()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        _isGraunded = collider.Length > 1;

        if (!_isGraunded)
        {
            _animator.Play("Jump");
        }

    }
}

    
