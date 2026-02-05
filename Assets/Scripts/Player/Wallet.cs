using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private CoinsPickUpHandler _coinsPickUpHandler;
    
    private int _balance;

    private void OnEnable()
    {
        _coinsPickUpHandler.IsPickedUp += AddCoins;
    }

    private void OnDisable()
    {
        _coinsPickUpHandler.IsPickedUp -= AddCoins;
    }

    public void Initialize(int value = 0)
    {
        _balance = value;
    }

    private void AddCoins(int value)
    {
        _balance += value;
        
        Debug.Log($"Balance: {_balance}");
    }
}