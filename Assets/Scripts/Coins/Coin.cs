using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    private Collider2D _collider;
    
    public int CoinValue { get; private set; } = 1;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>(); 
        _collider.isTrigger = true;
    }
}