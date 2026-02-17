using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Mover _mover;
    [SerializeField] private CoinsCollector _coinsCollector;
    [SerializeField] private DirectionChanger _directionChanger;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 15f;
    
    

    private float _horizontalInput;

    private void Update()
    {
        _horizontalInput = _userInput.GetMoveInput().x;
        Move(_horizontalInput);
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        _mover.CheckGround();
    }

    private void Move(float horizontalInput)
    {
        _mover.Move(horizontalInput, _speed);
        _directionChanger.SetDirection(horizontalInput);

        if (_userInput.GetJumpInput() && _mover.IsGrounded)
            _mover.Jump(_jumpForce);
    }

    private void UpdateAnimation()
    {
        _animationController.UpdateAnimation(
            Mathf.Abs(_mover.Velocity.x),
            _mover.IsGrounded,
            _mover.Velocity.y
        );
    }
}
