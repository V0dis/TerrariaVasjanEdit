using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;
    public Vector2 Velocity => _rigidbody != null ? _rigidbody.linearVelocity : Vector2.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        if (_rigidbody == null)
            return;
        
        _rigidbody.freezeRotation = true;
    }

    private void Start()
    {
        StartCoroutine(UpdaterGroundState());
    }

    private IEnumerator UpdaterGroundState()
    {
        CheckGround();
        yield return new WaitForSeconds(0.1f);
    }

    public void Jump(float jumpForce)
    {
        if (_rigidbody == null || !_isGrounded)
            return;

        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, jumpForce);
    }

    public void Move(float horizontalInput, float speed)
    {
        if (_rigidbody == null)
            return;

        _rigidbody.linearVelocity = new Vector2(horizontalInput * speed, _rigidbody.linearVelocity.y);
    }

    public void Move(Vector2 targetVelocity)
    {
        if (_rigidbody == null)
            return;
        
        _rigidbody.linearVelocity = new Vector2(targetVelocity.x, _rigidbody.linearVelocity.y);
    }

    public void CheckGround()
    {
        if (_rigidbody == null || _groundCheck == null)
        {
            _isGrounded = false;
            return;
        }
        
        Debug.DrawRay(_groundCheck.position, Vector2.down * _groundCheckRadius, Color.red);
        
        Collider2D hit = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        _isGrounded = hit != null;
    }
}