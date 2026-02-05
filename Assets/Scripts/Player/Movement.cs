using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private GroundChecker _groundChecker;
    
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
    }
    
    public void Jump()
    {
        if (_groundChecker.IsGrounded())
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
    }

    public void Move(float horizontalInput)
    {
        _rigidbody.linearVelocity = new Vector2(horizontalInput * _moveSpeed, _rigidbody.linearVelocity.y);
    }
}