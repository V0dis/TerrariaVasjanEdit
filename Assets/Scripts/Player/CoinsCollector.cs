using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CoinsCollector : MonoBehaviour
{
    private int _coins;
    
    public int Coins => _coins;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.Collected += OnCoinCollected;
        }
    }
    
    private void OnCoinCollected(Coin coin)
    {
        coin.Collected -= OnCoinCollected;
        _coins += coin.Value;
    }
}
