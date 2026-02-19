using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CoinsCollector : MonoBehaviour
{
    public event Action<int> OnCoinPickedUp;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            OnCoinPickedUp?.Invoke(coin.Value);
            coin.Take();
        }
    }
}
