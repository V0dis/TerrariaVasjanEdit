using System;
using UnityEngine;

public class CoinsPickUpHandler : MonoBehaviour
{
    public Action<int> IsPickedUp;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            IsPickedUp?.Invoke(coin.CoinValue);
            
            Destroy(coin.gameObject);
        }
    }
}