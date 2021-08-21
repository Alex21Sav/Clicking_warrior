using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _money;
    [SerializeField] private GameObject _effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out Player player))
        {            
            player.AddReward(_money);            
        }
        Die();
    }
    private void Die()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
