using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private int _value = 1;
    
    private bool _isCollected = false;
    public event Action<Coin> Collected;
    public int Value => _value;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isCollected || other.GetComponent<Player>() == null) 
            return;
        
        _isCollected = true;
        Collected?.Invoke(this);
    }
}