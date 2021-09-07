using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse = 10;
    [SerializeField] private AudioSource _jumpSound;    

    private bool _isGraunded;
    private bool _isGraundedAnimator;
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
        //if (_isGraunded && Input.GetKeyDown(KeyCode.Space))
        //{
        //    Jump();
        //}

        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began && _isGraunded)
            {
                Jump();
            }
        }

    }
    private void FixedUpdate()
    {
        CheckGraunded();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _animator.Play("Attack");
        }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Graunded graunded))
        {           
            _isGraunded = true;
        }
    }
    private void Jump()
    {
        _isGraunded = false;
        _rigidbody.AddForce(transform.up * _jumpForse, ForceMode2D.Impulse);
        _jumpSound.Play();
    }
    private void Run()
    {
        transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
    }
    private void CheckGraunded()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.45f);
        _isGraundedAnimator = collider.Length > 1.2;

        if (!_isGraundedAnimator)
        {
            _animator.Play("Jump");
        }
    }
}

    
