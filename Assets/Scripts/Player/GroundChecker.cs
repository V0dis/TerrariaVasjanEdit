using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 1f;
    [SerializeField] private Collider2D _playerCollider;

    private void Update()
    {
        IsGrounded();
    }

    public bool IsGrounded()
    {
        var hit = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius);
        return hit != null && hit != _playerCollider;
    }

    private void OnDrawGizmosSelected()
    {
        if (_groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
    }
}
