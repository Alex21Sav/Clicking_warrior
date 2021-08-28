using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerCoins : MonoBehaviour
{

    [SerializeField] private GameObject[] _coinTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
        
    private float _elapsedTime = 0;    

    public void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {   
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            int coinTemplatesNumber = Random.Range(0, _coinTemplates.Length);
            Instantiate(_coinTemplates[coinTemplatesNumber], _spawnPoints[spawnPointNumber].position, Quaternion.identity);
            _elapsedTime = 0;
        }
    }
}
