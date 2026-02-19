using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private int _value = 1;

    public event Action<Coin> IsTaken;

    public int Value => _value;

    public void Take()
    {
        IsTaken?.Invoke(this);
    }
}
