using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private CoinsCollector _coinsCollector;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private GroundChecker _groundChecker;
    
    [Header("Settings")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 15f;

    private void OnEnable()
    {
        _coinsCollector.CoinPickedUp += _wallet.AddCoins;
    }

    private void Update()
    {
        Move(_userInput.GetMoveInput().x);
        TryJump();
        RefreshAnimation();
    }

    private void OnDisable()
    {
        _coinsCollector.CoinPickedUp -= _wallet.AddCoins;
    }

    private void Move(float horizontalInput)
    {
        _mover.Move(new Vector2(horizontalInput * _speed, 0));
        _rotator.SetDirection(horizontalInput);
    }

    private void TryJump()
    {
        if (_userInput.GetJumpInput() && _groundChecker.IsGrounded)
            _jumper.Jump(_jumpForce);
    }

    private void RefreshAnimation()
    {
        _animator.SetSpeed(Mathf.Abs(_mover.Velocity.x));
        _animator.SetGrounded(_groundChecker.IsGrounded);
        _animator.SetAirSpeedY(_mover.Velocity.y);
    }
}