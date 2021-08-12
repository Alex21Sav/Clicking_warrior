using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMover : MonoBehaviour
{
    [SerializeField] private float _speed;

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
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
