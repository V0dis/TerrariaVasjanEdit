using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        if (_spawnPoints == null || _spawnPoints.Count == 0)
        {
            _spawnPoints = new List<Transform>();
            
            foreach (Transform child in transform)
                _spawnPoints.Add(child);
        }
        
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        if (_coinPrefab == null || _spawnPoints == null || _spawnPoints.Count == 0) return;
        
        foreach (var point in _spawnPoints)
            SpawnCoin(point.position);
    }

    private void SpawnCoin(Vector3 position)
    {
        var coin = Instantiate(_coinPrefab, position, Quaternion.identity);
        coin.Collected += HandleCoinCollected;
    }

    private void HandleCoinCollected(Coin coin)
    {
        coin.Collected -= HandleCoinCollected;
        Destroy(coin.gameObject);
    }
}
