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

    private float _horizontalInput;

    private void Start()
    {
        _groundChecker.Initialize();
    }

    private void Update()
    {
        _horizontalInput = _userInput.GetMoveInput().x;
        Move(_horizontalInput);
        RefreshAnimation();
    }

    private void OnEnable()
    {
        _coinsCollector.OnCoinPickedUp += _wallet.AddCoins;
    }

    private void OnDisable()
    {
        _coinsCollector.OnCoinPickedUp -= _wallet.AddCoins;
    }

    private void Move(float horizontalInput)
    {
        _mover.Move(new Vector2(horizontalInput * _speed, 0));
        _rotator.SetDirection(horizontalInput);

        if (_userInput.GetJumpInput())
            _jumper.Jump(_jumpForce, _groundChecker.IsGrounded);
    }

    private void RefreshAnimation()
    {
        _animator.SetAnimationParameters(
            Mathf.Abs(_mover.Velocity.x),
            _groundChecker.IsGrounded,
            _mover.Velocity.y
        );
    }
}