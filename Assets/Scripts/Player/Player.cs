using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Movement _movement;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private Wallet _wallet;
    
    private float _horizontalInput;
    
    private void Awake()
    {
        _wallet.Initialize();
    }

    private void Update()
    {
        Move();
        Animate();
        GetInput();
    }

    private void Move()
    {
        _movement.Move(_horizontalInput);
        
        if (_userInput.GetJumpInput())
            _movement.Jump();
    }

    private void Animate()
    {
        _animation.SetRun(_horizontalInput);
    }

    private void GetInput()
    {
        _horizontalInput = _userInput.GetMoveInput().x;
    }
    
    
}
